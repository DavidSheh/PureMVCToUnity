using UnityEngine;
using System.Collections;

using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LoginFacade : Facade
{
	public const string STARTUP = "startup";
	public const string SUBMIT_LOGIN = "submitLogin";
	public const string LOGIN_SUCCESSFUL = "loginSuccessful";
	public const string LOGIN_FAIL = "loginFail";

    public new static IFacade Instance
	{
		get
		{
			if (m_instance == null)
			{
				lock (m_staticSyncRoot)
				{
					if (m_instance == null) m_instance = new LoginFacade();
				}
			}

			return m_instance;
		}
	}


    protected override void InitializeController()
    {
		base.InitializeController();
        RegisterCommand(STARTUP, typeof(StartupCommand));
        RegisterCommand(SUBMIT_LOGIN, typeof(LoginCommand));
	}

	protected override void InitializeModel() 
    {
		base.InitializeModel();
		RegisterProxy(new UsersProxy());
	}

	protected override void InitializeView() 
    {
		base.InitializeView();
        UIBase page = UIManager.Instance.ShowView("LoginPanel");
        RegisterMediator(new LoginScreenMediator(page));
	}

    public void Startup()
    {
        NotifyObservers(new Notification(STARTUP, null, null));
    }
}
