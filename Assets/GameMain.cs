using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using cn.bmob.api;

public class GameMain : MonoBehaviour {

    public static GameMain instance = null;

    public BmobUnity bmob = null;

    void Awake()
    {
        instance = this;
        this.bmob = GameObject.FindObjectOfType<BmobUnity>();
    }

	// Use this for initialization
	void Start () {
        ((LoginFacade)LoginFacade.Instance).Startup();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
