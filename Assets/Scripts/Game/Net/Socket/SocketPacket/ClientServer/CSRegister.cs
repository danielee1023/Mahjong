﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class CSRegister : SocketPacket
{
	public BYTES mAccount = new BYTES(16);
	public BYTES mPassword = new BYTES(16);
	public BYTES mName = new BYTES(16);
	public INT mHead = new INT();
	public CSRegister(PACKET_TYPE type)
		:
		base(type)
	{
		fillParams();
		zeroParams();
	}
	public void setAccount(string account)
	{
		byte[] accountBytes = BinaryUtility.stringToBytes(account);
		mAccount.setValue(accountBytes);
	}
	public void setPassword(string password)
	{
		byte[] passwordBytes = BinaryUtility.stringToBytes(password);
		mPassword.setValue(passwordBytes);
	}
	public void setName(string name)
	{
		byte[] nameBytes = BinaryUtility.stringToBytes(name, Encoding.UTF8);
		mName.setValue(nameBytes);
	}
	protected override void fillParams()
	{
		pushParam(mAccount);
		pushParam(mPassword);
		pushParam(mName);
		pushParam(mHead);
	}
}