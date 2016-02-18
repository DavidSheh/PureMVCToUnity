using UnityEngine;
using System.Collections;

public class TipsPanel : UIBase
{
    public UILabel lblTips;

    protected override void Awake()
    {
        base.Awake();

        if (null == lblTips)
        {
            lblTips = transform.FindChild("LblTips").GetComponent<UILabel>();
        }
    }

    public void BtnOKClick()
    {
        UIManager.Instance.HideView("TipsPanel");
    }

    public void ShowTips(string tips)
    {
        if(null == lblTips)
        {
            Debug.LogError("lblTips is null!");
            return;
        }

        this.lblTips.text = tips;
    }
}
