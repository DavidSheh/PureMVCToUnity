using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using PureMVC.Patterns;
using PureMVC.Interfaces;

public class UsersProxy : Proxy 
{
	public const string NAME = "UsersProxy";

	public UsersProxy()
        : base(NAME, new Dictionary<string, string>())
    {
		Dictionary<string, string> localData = GetLocalData();
		localData.Add("user1", "pass1");
		localData.Add("user2", "pass2");
	}

    private Dictionary<string, string> GetLocalData()
    {
        return (Dictionary<string, string>)base.Data;
	}

	public bool CheckLogin(LoginVO userInfo)
    {
		Debug.Log("userInfo = " + userInfo);
        Dictionary<string, string> localData = GetLocalData();
		string userName = userInfo.Name;
		if(null==userName||userName.Trim().Length==0) return false;
		string pass = userInfo.Pwd;
		if(null==pass||pass.Trim().Length==0) return false;
		if(!localData.ContainsKey(userName)) return false;
		if(!pass.Equals(localData[userName])) return false;
		return true;
	}
}