using System;

using PureMVC.Patterns;
using PureMVC.Interfaces;

public class StartupCommand : SimpleCommand 
{
    //@Override
    //public void run() {
    //    try {
    //        for (LookAndFeelInfo info : UIManager.getInstalledLookAndFeels()) {
    //            if ("Nimbus".equals(info.getName())) {
    //                UIManager.setLookAndFeel(info.getClassName());
    //                break;
    //            }
    //        }
    //        LoginScreenMediator mediator = (LoginScreenMediator) this.facade.retrieveMediator(LoginScreenMediator.NAME);
    //        mediator.show();
    //    } catch (Exception e) {}
    //}

    //@Override
    //public void execute(INotification notification) {
    //    SwingUtilities.invokeLater(this);
    //}

    public override void Execute(INotification note)
	{
        //LoginScreenMediator mediator = (LoginScreenMediator)Facade.RegisterMediator(new LoginScreenMediator());
        //Facade.RegisterProxy(new UserProxy());
        //Facade.RegisterProxy(new RoleProxy());

        //MainWindow window = (MainWindow) note.Body;
        //Facade.RegisterMediator(new UserFormMediator(window.userForm));
        //Facade.RegisterMediator(new UserListMediator(window.userList));
        //Facade.RegisterMediator(new RolePanelMediator(window.rolePanel));
	}
}
