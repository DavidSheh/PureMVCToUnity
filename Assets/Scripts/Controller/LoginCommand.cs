using System;

using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LoginCommand : SimpleCommand {

	public override void Execute(INotification notification) 
    {
		UsersProxy usersProxy = (UsersProxy) Facade.RetrieveProxy(UsersProxy.NAME);
		LoginVO user = (LoginVO) notification.Body;
        //if(usersProxy.CheckLogin(userInfo))
        //{
        //    SendNotification(LoginFacade.LOGIN_SUCCESSFUL, null, null);
        //} 
        //else 
        //{
        //    SendNotification(LoginFacade.LOGIN_FAIL, null, null);
        //}

        GameMain.instance.bmob.Login<LoginVO>(user.username, user.password, (resp, exception) =>
        {
            if (exception != null)
            {
                string info = "登录失败, 失败原因为： " + exception.Message;
                SendNotification(LoginFacade.LOGIN_FAIL, info, null);
                return;
            }

           string msg = "登录成功, @" + resp.username + "$[" + resp.sessionToken + "]";

           SendNotification(LoginFacade.LOGIN_SUCCESSFUL, msg, null);
        });
	}
}
