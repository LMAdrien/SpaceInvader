using UnityEngine;
using System.Collections;

public class RoboBoss : MonoBehaviour {

	public Transform target;
	public float bossSpeed;
	int PVBoss;
	private float seccondsUntilfire;
	private float startTime;
	public Transform leftSpawn;
	public Transform rightSpawn;
	public LaserScript bulletPrefab;
	private Level2Panel panel;

	void Start () {
		bossSpeed = 12f;
		PVBoss = 1000;
		seccondsUntilfire = 1.2f;
		startTime = Time.time;
		panel = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Level2Panel>();
	}
	
	void Update () {
		if (target != null) {
			Vector3 lookAtPosition = target.position;
			lookAtPosition.y = transform.position.y;
			transform.LookAt(lookAtPosition);
			transform.position += transform.forward * bossSpeed * Time.deltaTime;
			if (Time.time - startTime >= seccondsUntilfire) {
				startTime = Time.time;
				GameObject.Instantiate (bulletPrefab, leftSpawn.position, leftSpawn.rotation);
				GameObject.Instantiate (bulletPrefab, rightSpawn.position, rightSpawn.rotation);
			}
		}
	}


	public void damageController(string objectTag){
		switch (objectTag) 
		{
		case "leftBossLeg":
			SetPv(2);
			panel.ShootEnnemy(20);
			break;
		case "rightBossLeg":
			SetPv(2);
			panel.ShootEnnemy(20);
			break;
		case "leftBossArm":
			SetPv(2);
			panel.ShootEnnemy(20);
			break;
		case "rightBossArm":
			SetPv(2);
			panel.ShootEnnemy(20);
			break;
		case "headBoss":
			SetPv(8);
			panel.ShootEnnemy(80);
			break;
		}
	}

	void SetPv(int nbr)
	{
		PVBoss -= nbr;
		if (PVBoss < 1) {
			Destroy (this.gameObject);
			Application.LoadLevel(4);
		}
			
	}
	
	public int GetPv()
	{
		return PVBoss;
	}
}
