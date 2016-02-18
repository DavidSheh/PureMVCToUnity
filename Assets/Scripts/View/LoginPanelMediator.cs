using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using PureMVC.Patterns;
using PureMVC.Interfaces;
using cn.bmob.io;

public class LoginPanelMediator : Mediator 
{
    public const string NAME = "LoginPanelMediator";
	private LoginPanel dialog;

	public LoginPanelMediator(UIBase viewComponent)
        : base(NAME, viewComponent)
    {
        dialog = (LoginPanel)viewComponent;
        dialog.Login += new EventHandler(Login);
        dialog.Signup += new EventHandler(Signup);
	}

    public override IList<string> ListNotificationInterests()
	{
		IList<string> list = new List<string>();
		list.Add(LoginFacade.LOGIN_SUCCESSFUL);
		list.Add(LoginFacade.LOGIN_FAIL);
        list.Add(LoginFacade.SIGNUP_SUCCESSFUL);
        list.Add(LoginFacade.SIGNUP_FAIL);
		return list;
	}

    public override void HandleNotification(INotification note)
	{
        string tips = (string)note.Body;

        UIManager.Instance.HideView("LoginPanel");
        UIBase page = UIManager.Instance.ShowView("TipsPanel");
        //string tips = "";
        //switch (note.Name)
        //{
        //    case LoginFacade.LOGIN_SUCCESSFUL:
        //        //UserForm.ShowUser(login, UserFormMode.ADD);
        //        // 显示登陆成功界面
        //        tips = "登陆成功!";
        //        break;
        //    case LoginFacade.LOGIN_FAIL:
        //        //UserForm.ShowUser(login, UserFormMode.EDIT);
        //        // 显示登陆失败界面
        //        tips = "登陆失败!";
        //        break;
        //    case LoginFacade.SIGNUP_SUCCESSFUL:
        //        // 显示注册成功界面
        //        tips = "注册成功!";
        //        break;
        //    case LoginFacade.SIGNUP_FAIL:
        //        // 显示注册失败界面
        //        tips = "注册失败!";
        //        break;
        //}

        if (null != page)
        {
            ((TipsPanel)page).ShowTips(tips);
        }
	}

    void Login(object sender, EventArgs e)
    {
        LoginArgs args = (LoginArgs)e;
        string name = args.Name;
        string pass = args.Pwd;

		LoginVO userInfo = new LoginVO();
        userInfo.username = name;
        userInfo.password = pass;
        userInfo.email = "aaa@qq.cn";
        
		Facade.NotifyObservers(new Notification(LoginFacade.SUBMIT_LOGIN, userInfo, null));
    }

    void Signup(object sender, EventArgs e)
    {
        LoginArgs args = (LoginArgs)e;
        string name = args.Name;
        string pass = args.Pwd;

        LoginVO user = new LoginVO();
        user.username = name;
        user.password = pass;
        user.email = "aaa@qq.cn";

        //GameMain.instance.bmob.Signup<LoginVO>(user, (resp, exception) =>
        //{
        //    if (exception != null)
        //    {
        //        Debug.LogError("注册失败, 失败原因为： " + exception.Message);
        //        return;
        //    }

        //    Debug.Log("注册成功");
        //});

        Facade.NotifyObservers(new Notification(LoginFacade.SUBMIT_SIGNUP, user, null));
    }
}