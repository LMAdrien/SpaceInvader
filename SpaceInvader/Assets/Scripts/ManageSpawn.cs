using UnityEngine;
using System.Collections;

public class ManageSpawn : MonoBehaviour {

	public GameObject[] spawn;
	private float startTime;
	private float timespawn;

	void Start () {
		startTime = Time.time;
		timespawn = 3;
	}
	
	void Update () {
		if (Time.time - startTime >= timespawn) {
			startTime = Time.time;
			int rand = Random.Range (0, spawn.Length);
			spawn [rand].GetComponent<SpawnEnnemy> ().Launch ();
		}
	}
}
