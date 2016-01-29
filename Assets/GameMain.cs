using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

public class GameMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ((LoginFacade)LoginFacade.Instance).Startup();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
