using UnityEngine;
using System.Collections;

public class playernotmove : MonoBehaviour {

	public float directionSpeed;
	public Bullet bulletPrefab;
	public Transform leftSpawn;
	public Transform rightSpawn;
	public Transform centerSpawn;
	private bool canmoveg;
	private bool canmoved;
	private bool canmoveb;
	private bool canmoveh;
	private PanelGame canvas;
	public int PV;
	public AudioSource src;

	void Start () {
		directionSpeed = 6.0f;
		PV = 100;
		canmoveg = true;
		canmoveh = true;
		canmoved = true;
		canmoveb = true;
	}

	void Update ()
	{
		Vector3 move = Vector3.zero;
		
		if (Input.GetKey(KeyCode.RightArrow) && canmoved){
			move += Vector3.right * directionSpeed; 
		}
		
		if (Input.GetKey(KeyCode.LeftArrow) && canmoveg){
			move += Vector3.left * directionSpeed; 
		}
		
		if (Input.GetKey(KeyCode.UpArrow) && canmoveh){
			move += Vector3.up * directionSpeed; 
			
		}
		
		if (Input.GetKey(KeyCode.DownArrow) && canmoveb){
			move += Vector3.down * directionSpeed;
		}
		
		this.gameObject.transform.position += move * directionSpeed * Time.deltaTime;
		
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

	}
	
	void rotationcube(float y)
	{
		Vector3 tmp = this.transform.eulerAngles;
		tmp.y = y + (this.transform.eulerAngles.y);
		this.transform.eulerAngles = tmp;
	}
	void OnTriggerStay(Collider other){
		if (other.gameObject == GameObject.FindGameObjectWithTag ("murg"))
			canmoveg = false;
		if (other.gameObject == GameObject.FindGameObjectWithTag ("murd"))
			canmoved = false;
		if (other.gameObject == GameObject.FindGameObjectWithTag ("murh"))
			canmoveh = false;
		if (other.gameObject == GameObject.FindGameObjectWithTag ("murb"))
			canmoveb = false;
	}

	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject == GameObject.FindWithTag ("ennemy"))
			SetPv (10);
		if (c.gameObject.tag == "fireennemy")
			SetPv (1);
	}

	void SetPv(int nbr)
	{
		PV -= nbr;
		if (PV < 1) {
			Destroy (this.gameObject);
			Application.LoadLevel(5);
		}
	}

	public int GetPv()
	{
		return PV;
	}

	void OnTriggerExit(Collider other){
		canmoveg = true;
		canmoveh = true;
		canmoved = true;
		canmoveb = true;
	}
}
