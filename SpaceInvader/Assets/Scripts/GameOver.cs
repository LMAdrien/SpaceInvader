using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	float startTime;
	float timeToChange;

	void Start () {
		startTime = Time.time;
		timeToChange = 10;
	}

	void Update () {
		if (Time.time - startTime >= timeToChange) {
			Application.LoadLevel(0);
		}
	}
}
