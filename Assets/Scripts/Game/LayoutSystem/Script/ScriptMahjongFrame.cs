﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ScriptMahjongFrame : LayoutScript
{
	protected txUIObject mRoomInfoRoot;
	protected txNGUIText mRoomIDLabel;
	protected txNGUIButton mLeaveRoomButton;
	protected txNGUIButton mReadyButton;
	protected txNGUIButton mCancelReadyButton;
	protected txNGUIText mInfo;
	public ScriptMahjongFrame(string name, GameLayout layout)
		:
		base(name, layout)
	{
		;
	}
	public override void assignWindow()
	{
		newObject(out mRoomInfoRoot, "RoomInfoRoot");
		newObject(out mRoomIDLabel, mRoomInfoRoot, "RoomID");
		newObject(out mLeaveRoomButton, "LeaveRoom");
		newObject(out mReadyButton, "Ready");
		newObject(out mCancelReadyButton, "CancelReady");
		newObject(out mInfo, "Info");
	}
	public override void init()
	{
		mGlobalTouchSystem.registeBoxCollider(mLeaveRoomButton, onLeaveRoomClick, null, onButtonPress);
		mGlobalTouchSystem.registeBoxCollider(mReadyButton, onReadyClick, null, onButtonPress);
		mGlobalTouchSystem.registeBoxCollider(mCancelReadyButton, onCancelReadyClick, null, onButtonPress);
	}
	public override void onReset()
	{
		notifyReady(false);
	}
	public override void onShow(bool immediately, string param)
	{
		;
	}
	public override void onHide(bool immediately, string param)
	{
		;
	}
	public override void update(float elapsedTime)
	{
		;
	}
	public void setRoomID(int roomID)
	{
		mRoomIDLabel.setLabel(StringUtility.intToString(roomID));
	}
	public void notifyReady(bool ready)
	{
		LayoutTools.ACTIVE_WINDOW(mReadyButton, !ready);
		LayoutTools.ACTIVE_WINDOW(mCancelReadyButton, ready);
	}
	public void notifyStartGame()
	{
		LayoutTools.ACTIVE_WINDOW(mReadyButton, false);
		LayoutTools.ACTIVE_WINDOW(mCancelReadyButton, false);
	}
	public void notifyInfo(string info)
	{
		mInfo.setLabel(info);
	}
	//-----------------------------------------------------------------------------------
	protected void onReadyClick(txUIObject go)
	{
		// 发送消息通知服务器玩家已经准备
		CSReady packetReady = mSocketNetManager.createPacket<CSReady>();
		packetReady.mReady.mValue = true;
		mSocketNetManager.sendMessage(packetReady);
	}
	protected void onCancelReadyClick(txUIObject go)
	{
		// 发送消息通知服务器玩家已经准备
		CSReady packetReady = mSocketNetManager.createPacket<CSReady>();
		packetReady.mReady.mValue = false;
		mSocketNetManager.sendMessage(packetReady);
	}
	protected void onLeaveRoomClick(txUIObject go)
	{
		mSocketNetManager.sendMessage<CSLeaveRoom>();
	}
	protected void onButtonPress(txUIObject go, bool press)
	{
		LayoutTools.SCALE_WINDOW(go, go.getScale(), press ? new Vector2(1.2f, 1.2f) : Vector2.one, 0.2f);
	}
}