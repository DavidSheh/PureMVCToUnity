using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LoginScreenMediator : Mediator 
{
	public const string NAME = "LoginScreenMediator";
	private LoginScreen dialog;

	public LoginScreenMediator(UIBase viewComponent)
        : base(NAME, viewComponent)
    {
        dialog = (LoginScreen)viewComponent;
        dialog.Login += new EventHandler(Login);
	}

    public override IList<string> ListNotificationInterests()
	{
		IList<string> list = new List<string>();
		list.Add(LoginFacade.LOGIN_SUCCESSFUL);
		list.Add(LoginFacade.LOGIN_FAIL);
		return list;
	}

    public override void HandleNotification(INotification note)
	{
		LoginVO login;

		switch (note.Name)
		{
			case LoginFacade.LOGIN_SUCCESSFUL:
				login = (LoginVO) note.Body;
                
				//UserForm.ShowUser(login, UserFormMode.ADD);
                // 显示登陆成功界面
                Debug.LogError("登陆成功！");
				break;
			case LoginFacade.LOGIN_FAIL:
				login = (LoginVO) note.Body;
				//UserForm.ShowUser(login, UserFormMode.EDIT);
                // 显示登陆失败界面
                Debug.LogError("登陆失败！");
				break;

		}
	}

    void Login(object sender, EventArgs e)
    {
        LoginArgs args = (LoginArgs)e;
        string name = args.Name;// dialog.userName.getText();
        string pass = args.Pwd;// new string(dialog.password.getPassword());
		LoginVO userInfo = new LoginVO( name, pass );
		Facade.NotifyObservers(new Notification(LoginFacade.SUBMIT_LOGIN, userInfo, null));
    }
}