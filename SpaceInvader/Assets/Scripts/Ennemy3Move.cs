using UnityEngine;
using System.Collections;

public class Ennemy3Move : MonoBehaviour {

	private GameObject player;
	public BulletEnnemy bulletPrefab;
	public Transform leftSpawn;
	public Transform rightSpawn;
	private float seccondsUntilfire;
	private float startTime;
	private PanelGame canvas;

	void Start () {
		startTime = Time.time;
		seccondsUntilfire = 0.5f;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
		if (player != null) {
			Vector3 tmp = this.transform.position;
			
			tmp.z += (-tmp.z)/5 * Time.deltaTime;
			tmp.x += (player.transform.position.x - tmp.x)/5 * Time.deltaTime;
			tmp.y += (player.transform.position.y - tmp.y)/5 * Time.deltaTime;
			this.transform.position = tmp;
			this.transform.LookAt (player.transform);
			if (Time.time - startTime >= seccondsUntilfire) {
				startTime = Time.time;
				GameObject.Instantiate (bulletPrefab, leftSpawn.position, leftSpawn.rotation);
				GameObject.Instantiate (bulletPrefab, rightSpawn.position, rightSpawn.rotation);
			}
		}
	}
	
	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag != "fireennemy" && c.gameObject.tag == "Fire") {
			GameObject.FindWithTag ("Canvas").GetComponent<PanelGame> ().ShootEnnemy ();
			Destroy (this.gameObject);
		} else if (c.gameObject.tag != "fireennemy") {
			Destroy(this.gameObject);
		}
	}
}
