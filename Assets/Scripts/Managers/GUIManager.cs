using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
    public string controlMessage = "[W] = Forward\n[S] = Backward\n[A] = Left\n[D] = Right\n[Mouse] = Look\n[Space] = Jump\n";
	void Start () {
	    
	}
	
	void Update () {

    }

    void OnGUI() {

        //Controls
        GUI.Box(new Rect(10, 110, 100, 190), "Controls");
        GUI.Box(new Rect(10, 130, 100, 170), "[W] = Forward\n[S] = Backward\n[A] = Left\n[D] = Right\n[Mouse] = Look\n[Space] = Jump\n");

        //Inventory
        GUI.Box(new Rect(Screen.width/4, 10, Screen.width/2, 100),"Inventory");

        //Buildings
        GUI.Box(new Rect(Screen.width - 110, 110, 100, 300), "Buildings");
        

    }
}
