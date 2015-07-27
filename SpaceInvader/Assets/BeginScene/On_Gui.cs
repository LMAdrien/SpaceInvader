using UnityEngine;
using System.Collections;

public class On_Gui : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnGUI(){

		if (GUI.Button (new Rect (0, Screen.height - 50, 100, 50), "Exit Game")) {
			Application.Quit();
			Debug.Log("Exit");
		}
	}
}
