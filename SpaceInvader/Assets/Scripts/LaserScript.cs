using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	private float speed;
	private float seccondsUntilDestroy;
	private float startTime;
	private GameObject player;
	Vector3 lastpost;
	
	void Start () {
		
		startTime = Time.time;
		speed = 1.0f;
		seccondsUntilDestroy = 4.0f;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		if (GameObject.FindGameObjectWithTag("Player") != null) {
			float distance = Vector3.Distance(this.transform.position, player.transform.position);
			
			if (distance >= 80) {
				Vector3 lookAtPosition = player.transform.position;
				lastpost = lookAtPosition;
			}
			transform.LookAt(lastpost);
			transform.Translate (Vector3.forward * Time.deltaTime * 800);
			
			if (Time.time - startTime >= seccondsUntilDestroy)
				Destroy (this.gameObject);
			if (Time.time - startTime >= seccondsUntilDestroy)
				Destroy (this.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Player" && c.gameObject.tag != "fireennemy") {
			Destroy (this.gameObject);
		}
	}
}