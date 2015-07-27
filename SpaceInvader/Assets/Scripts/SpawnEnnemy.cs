using UnityEngine;
using System.Collections;

public class SpawnEnnemy : MonoBehaviour {

	public GameObject[] ennemy;
	
	public void Launch()
	{
		int rand = Random.Range (0, ennemy.Length);
		Instantiate (ennemy [rand], transform.position, transform.rotation);
	}
}
