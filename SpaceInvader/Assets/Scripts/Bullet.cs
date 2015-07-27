using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private float speed;
	private float seccondsUntilDestroy;
	private float startTime;

	public Vector3 Direction {
		get;
		set;
	}

	void Start () {
		startTime = Time.time;
		speed = 200.0f;
		seccondsUntilDestroy = 2;
	}


	void Update () {
		this.transform.position += Direction * speed * Time.deltaTime;
		if (Time.time - startTime >= seccondsUntilDestroy)
			Destroy (this.gameObject);
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag != "Player" && c.gameObject.tag != "Fire")
			Destroy (this.gameObject);
	}
}
