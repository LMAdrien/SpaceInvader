using UnityEngine;
using System.Collections;

public class RotationPlanet : MonoBehaviour {

	void Update () {
		Vector3 tempo = this.transform.eulerAngles;
		tempo.y = 5 * Time.deltaTime + (this.transform.eulerAngles.y);
		this.transform.eulerAngles = tempo;
	}
}
