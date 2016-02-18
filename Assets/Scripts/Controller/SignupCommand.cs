using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class SignupCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        UsersProxy usersProxy = (UsersProxy)Facade.RetrieveProxy(UsersProxy.NAME);
        LoginVO user = (LoginVO)notification.Body;
        GameMain.instance.bmob.Signup<LoginVO>(user, (resp, exception) =>
        {
            if (exception != null)
            {
                string info = "注册失败, 失败原因为： " + exception.Message;
                SendNotification(LoginFacade.LOGIN_SUCCESSFUL, info, null);
                return;
            }

            string msg = "注册成功!";
            SendNotification(LoginFacade.LOGIN_SUCCESSFUL, msg, null);
        });
    }
}