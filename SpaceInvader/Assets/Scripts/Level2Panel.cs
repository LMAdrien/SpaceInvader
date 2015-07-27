using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level2Panel : MonoBehaviour {

	
	private string formatLife = "Life : {0}";
	private string formatScore = "Score : {0}";
	private string formatBoss= "Boss : {0}";
	public Text reference;
	public Text referenceScore;
	public Text referenceBoss;
	private RoboBoss boss;
	private PlayerMove playerboss;
	private int pv;
	private int score;
	
	void Start () {
		boss = GameObject.FindWithTag ("Boss").GetComponent<RoboBoss>();
		score = 0;
		playerboss = GameObject.FindWithTag ("Player").GetComponent<PlayerMove>();
		score = PlayerPrefs.GetInt("Score");
		referenceScore.text = string.Format (formatScore, score);
	}
	
	void Update () {
			UpdateText ();
	}
	
	public void UpdateText()
	{
		referenceScore.text = string.Format (formatScore, score);
		reference.text = string.Format (formatLife, playerboss.GetPv());
		referenceBoss.text = string.Format (formatBoss, boss.GetPv ());
	}
	
	public void ShootEnnemy(int add)
	{
		score += 100;
		if(PlayerPrefs.GetInt("HighScore") < score){
			PlayerPrefs.SetInt("HighScore", score);
		}
	}
}
