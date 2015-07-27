using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelGame : MonoBehaviour {

	private string formatLife = "Life : {0}";
	private string formatScore = "Score : {0}";
	public Text reference;
	public Text referenceScore;
	private playernotmove player;
	private PlayerMove playerboss;
	private int pv;
	private int score;


	void Start () {
		score = 0;
		player = GameObject.FindWithTag ("Player").GetComponent<playernotmove>();
		referenceScore.text = string.Format (formatScore, score);
	}
	
	void Update () {
		if (Application.loadedLevel == 1) 
			UpdateText ();
	}

	public void UpdateText()
	{
		referenceScore.text = string.Format (formatScore, score);
		reference.text = string.Format (formatLife, player.GetPv());                               
	}

	public void ShootEnnemy()
	{
		score += 100;
		PlayerPrefs.SetInt("Score", score);
		if(PlayerPrefs.GetInt("HighScore") < score){
			PlayerPrefs.SetInt("HighScore", score);
		}
	}
	
}
