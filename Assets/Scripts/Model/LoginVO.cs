using System;

public class LoginVO {

    private string name = "";
    /// <summary>
    /// ”√ªß√˚
    /// </summary>
    public string Name{ get; private set; }

    private string pwd;
    /// <summary>
    /// √‹¬Î
    /// </summary>
    public string Pwd { get; private set; }

    public LoginVO(string name, string pwd) 
    {
		this.Name = name;
		this.Pwd = pwd;
	}

    public override string ToString()
    {
		return "LoginVO [name=" + name + ", pass=" + pwd + "]";
	}
}
