using UnityEngine;
using System.Collections;

public class RoboBossColision : MonoBehaviour {

	private RoboBoss bossFunctions;
	public GameObject boss;

	void Start () {
		bossFunctions = boss.GetComponent<RoboBoss> ();
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Fire") {
			bossFunctions.damageController (this.tag);
			Destroy (col.gameObject);
		}
	}
}
