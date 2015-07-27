using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadOnClick : MonoBehaviour {

	private string formatScore = "HighScore : {0}";
	public Text reference;

	void Start () {
		reference.text = string.Format (formatScore, PlayerPrefs.GetInt("HighScore")); 
	}

	public void newGameButton(int state){
		Application.LoadLevel (state);
	}

	public void exitGameButton(){
		Application.Quit ();
	}
}
