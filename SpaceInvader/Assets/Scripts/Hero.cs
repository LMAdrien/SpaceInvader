using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	Vector3 vector;
	int move = 0;

	
	void Update () {
		vector = transform.position;
		if (vector.z < 5 && move == 0)
			transform.Translate (Vector3.forward * Time.deltaTime);
		else {
			move = 1;
			transform.Translate (Vector3.back * Time.deltaTime);
		}
	}
}
