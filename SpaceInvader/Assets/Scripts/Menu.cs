using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public Text AffHighScore;
	private string format;

	void Start () {
		format  = "High Score : {0}";
		AffHighScore.text = string.Format (format, PlayerPrefs.GetInt("HighScore"));
	}
}
