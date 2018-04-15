﻿using System;
using System.Collections;
using System.Collections.Generic;

public class SCNotifyGetStartMahjong : SocketPacket
{
	public INT mPlayerGUID = new INT();
	public BYTE mMahjong = new BYTE();
	public SCNotifyGetStartMahjong(PACKET_TYPE type)
		:
		base(type)
	{
		fillParams();
		zeroParams();
	}
	protected override void fillParams()
	{
		pushParam(mPlayerGUID);
		pushParam(mMahjong);
	}
	public override void execute()
	{
		CommandCharacterGetStart cmd = newCmd(out cmd);
		cmd.mMahjong = (MAHJONG)mMahjong.mValue;
		pushCommand(cmd, mCharacterManager.getCharacter(mPlayerGUID.mValue));
	}
}