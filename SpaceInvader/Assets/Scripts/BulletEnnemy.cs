using UnityEngine;
using System.Collections;

public class BulletEnnemy : MonoBehaviour {

	private float speed;
	private float seccondsUntilDestroy;
	private float startTime;
	private GameObject player;
	private Vector3 directionplayer;
	
	void Start () {

		startTime = Time.time;
		speed = 1.0f;
		seccondsUntilDestroy = 6.0f;
		player = GameObject.FindGameObjectWithTag("Player");
		directionplayer = player.transform.position;
		this.transform.LookAt (player.transform);
	}
	
	
	void Update () {
		Vector3 tmp = this.transform.position;
		
		tmp.z += (-tmp.z)* speed * Time.deltaTime;
		tmp.x += (directionplayer.x - tmp.x)* speed  * Time.deltaTime;
		tmp.y += (directionplayer.y - tmp.y)*30* speed * Time.deltaTime;
		this.transform.position = tmp;
		if (Time.time - startTime >= seccondsUntilDestroy)
			Destroy (this.gameObject);
	}
	
	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Player") {
			Destroy (this.gameObject);
		} else if (c.gameObject.tag != "fireennemy") {
			Destroy(this.gameObject);
		}
	}
}
