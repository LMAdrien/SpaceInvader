using UnityEngine;
using System.Collections;

public class moveplanet : MonoBehaviour {

	public GameObject player;
	private float levelTime;
	private float startTime;

	void Start () {
		startTime = Time.time;
		levelTime = 120;
	}
	
	void Update () {
		if (Time.time - startTime >= levelTime) {
			PlayerPrefs.SetInt("Pv", GameObject.FindWithTag ("Player").GetComponent<playernotmove>().GetPv());
			Application.LoadLevel (2);
		}
		if (player != null) {
			Vector3 tmp = this.transform.position;
			
			tmp.z += (player.transform.position.z - tmp.z)/100 * Time.deltaTime;
			tmp.x += (player.transform.position.x - tmp.x)/100 * Time.deltaTime;
			tmp.y += (player.transform.position.y - tmp.y)/100 * Time.deltaTime;
			this.transform.position = tmp;
			this.transform.LookAt (player.transform);
		}	
	}
}
