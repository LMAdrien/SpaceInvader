using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AnimEnnemy : MonoBehaviour {
	
	public ParticleSystem[] animation;
	public GameObject panel;
	private PanelGame script;
	public AudioSource src;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
			
	}



	void OnDestroy() {
		//src.Play ();
		ParticleSystem toto2 = Instantiate (animation[0], this.gameObject.transform.position, this.gameObject.transform.rotation) as ParticleSystem;
		Destroy (toto2.gameObject, toto2.duration);
			
	}
}



