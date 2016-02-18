using UnityEngine;
using System.Collections.Generic;

public class UIManager
{
    #region 单例模式
    private UIManager() { }
    private static UIManager _instance;
    public static UIManager Instance
    {
        get { return _instance ?? (_instance = new UIManager()); }
    }
    #endregion

    private Dictionary<string, UIBase> pageDic = new Dictionary<string, UIBase>();

    public UIBase ShowView(string name)
    {
        //UIBase page = Resources.Load(name, typeof(UIBase)) as UIBase;
        UIBase page = null;
        if(pageDic.TryGetValue(name, out page))
        {
            page.gameObject.SetActive(true);
            return page;
        }
        GameObject prefab = Resources.Load(name, typeof(GameObject)) as GameObject;
        GameObject obj = Object.Instantiate(prefab);
        obj.name = name;
        page = obj.GetComponent<UIBase>();
        GameObject parentObj = GameObject.Find("UI Root");
        if(null != parentObj)
        {
            obj.transform.SetParent(parentObj.transform, false);
        }

        pageDic[name] = page;
        return page;
    }

    public UIBase HideView(string name)
    {
        UIBase page = null;
        if (pageDic.TryGetValue(name, out page))
        {
            page.gameObject.SetActive(false);
        }

        return page;
    }
}
