using System;
using UnityEngine;
using System.Collections;

public class LoginPanel : UIBase
{
    public event EventHandler Login;
    public event EventHandler Signup;

    public UIInput name;
    public UIInput pwd;

    protected override void Awake()
    {
        base.Awake();

        if(null == name)
        {
            name = transform.FindChild("LblName").GetComponent<UIInput>();
            
        }

        if(null == pwd)
        {
            pwd = transform.FindChild("LblPwd").GetComponent<UIInput>();
        }
    }

    public void BtnLoginClick()
    {
        string mName = name.value;
        string mPwd = pwd.value;
        EventArgs args = new LoginArgs(mName, mPwd);
        if(Login != null) Login(this, args);
    }

    public void BtnSignupClick()
    {
        string mName = name.value;
        string mPwd = pwd.value;
        EventArgs args = new LoginArgs(mName, mPwd);
        if (Signup != null) Signup(this, args);
    }
}

public class LoginArgs : EventArgs
{
    public string Name { get; private set; }
    public string Pwd { get; private set; }

    public LoginArgs(string name, string pwd)
    {
        this.Name = name;
        this.Pwd = pwd;
    }
}

