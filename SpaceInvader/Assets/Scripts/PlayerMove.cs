using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float directionSpeed;
	public float forwardSpeed;
	public Bullet bulletPrefab;
	public Transform leftSpawn;
	public Transform rightSpawn;
	public Transform centerSpawn;
	public AudioSource src;
	public GameObject Linerender;
	GameObject Line;
	private float secondsToDisplay;
	private float startTime;
	public int PV;

	void Start () {
		Line = GameObject.Instantiate (Linerender) as GameObject;
		Line.SetActive (false);
		secondsToDisplay = 2.0f;
		PV =  PlayerPrefs.GetInt("Pv");
		src.Stop ();
	}
	
	void Update ()
	{
		Vector3 move = Vector3.zero;
		if (Time.time - startTime >= secondsToDisplay) {
			Line.SetActive(false);
		}

		if (Input.GetKey(KeyCode.RightArrow)){
			transform.Rotate(0, 1, 0, Space.World);
		}

		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.Rotate(0, -1, 0, Space.World);
		}

		if (Input.GetKey(KeyCode.UpArrow)){
			move += Vector3.up * directionSpeed; 

		}

		if (Input.GetKey(KeyCode.DownArrow)){
			move += Vector3.down * directionSpeed;
		}

		this.gameObject.transform.position += move * directionSpeed * Time.deltaTime;
		this.gameObject.transform.position += transform.forward * forwardSpeed * Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.Space)) {
			Bullet bul = GameObject.Instantiate(bulletPrefab,
			                                    leftSpawn.position,
			                                    leftSpawn.rotation) as Bullet;
			bul.Direction = leftSpawn.forward;

			Bullet bul2 = GameObject.Instantiate(bulletPrefab,
			                                    rightSpawn.position,
			                                    rightSpawn.rotation) as Bullet;
			bul2.Direction = rightSpawn.forward;
			Bullet bul3 = GameObject.Instantiate(bulletPrefab,
			                                     centerSpawn.position,
			                                     centerSpawn.rotation) as Bullet;
			bul3.Direction = centerSpawn.forward;
			src.Play();
		}

		float terrainHeight = Terrain.activeTerrain.SampleHeight (transform.position);
		terrainHeight += 3f;

		if (terrainHeight > this.transform.position.y) {
			this.transform.position = new Vector3(transform.position.x,
			                                      terrainHeight,
			                                      transform.position.z
			                                      );
		}
	}

	void rotationcube(float y)
	{
		Vector3 tmp = this.transform.eulerAngles;
		tmp.y = y + (this.transform.eulerAngles.y);
		this.transform.eulerAngles = tmp;

	}
	
	void OnTriggerExit(Collider other){
			directionSpeed *= -1;
			Vector3 tmp = this.transform.position;
		if (this.transform.position.y > 145) {
				tmp.y -=5;
				this.transform.position = tmp;
			Line.SetActive(true);
			startTime = Time.time;
		} 
		if (this.transform.position.y < 10) {
			Destroy (this.gameObject);
			Line.SetActive (true);
			startTime = Time.time;
		}
		if (this.transform.position.x > 980 || this.transform.position.x < 10 || this.transform.position.z > 980 || this.transform.position.z < 10)
			{
				Line.SetActive(true);
				startTime = Time.time;
				rotationcube(180);
			}
	}

	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject == GameObject.FindWithTag ("Boss"))
			SetPv (5);
		if (c.gameObject.tag == "fireennemy")
			SetPv (1);
	}
	
	void SetPv(int nbr)
	{
		PV -= nbr;
		if (PV < 1) {
			PV = 0;
			Destroy (this.gameObject);
			Application.LoadLevel(5);
		}
			
	}
	
	public int GetPv()
	{
		return PV;
	}

}
