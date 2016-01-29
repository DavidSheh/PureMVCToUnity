using System;

using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LoginCommand : SimpleCommand {

	public override void Execute(INotification notification) 
    {
		UsersProxy usersProxy = (UsersProxy) Facade.RetrieveProxy(UsersProxy.NAME);
		LoginVO userInfo = (LoginVO) notification.Body;
		if(usersProxy.CheckLogin(userInfo))
        {
			SendNotification(LoginFacade.LOGIN_SUCCESSFUL, null, null);
		} 
        else 
        {
			SendNotification(LoginFacade.LOGIN_FAIL, null, null);
		}
	}
}
