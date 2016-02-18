using cn.bmob.io;
using System;

public class LoginVO : BmobUser
{
    public override void write(BmobOutput output, bool all)
    {
        base.write(output, all);
    }

    public override void readFields(BmobInput input)
    {
        base.readFields(input);
    }

    public override string ToString()
    {
		return "LoginVO [name=" + this.username + ", pass=" + this.password + "]";
	}
}
