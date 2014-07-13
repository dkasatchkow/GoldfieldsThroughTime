using UnityEngine;
using System.Collections;

public class EnemeScript : MonoBehaviour {

	public GameObject player;
	public GameObject bullet;
	public float firingRate = 1.0f;
	public float delayFire = 3.0f;
	public float speed = 1.0f;
	public float rotation = 1.0f;
	public float FallSpeed = 0.1f;
	public float Falllevel = 0.5f;
	private bool isfiring = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance(transform.position,player.transform.position)<50 && isfiring == false)
		{
			// invoke firing per time
			InvokeRepeating ("FireBullet", delayFire, firingRate);
			isfiring = true;
		}

		// look at the player
		//Quaternion oldRot = transform.rotation;
		transform.LookAt (player.transform.position);
		//Quaternion newRot = transform.rotation;
		//newRot.y = oldRot.y;
		//transform.LookAt (player.transform.position);
		//transform.rotation = new Quaternion (newRot.x, transform.position.y, newRot.z, 1);
		// move forward
		transform.position += transform.forward * speed *
			Time.deltaTime;

		//FallSpeed
		if (transform.position.y > Falllevel )
		{
			transform.Translate (0, -FallSpeed, 0);
		}
		if (transform.position.y < Falllevel )
		{
			transform.Translate (0, FallSpeed, 0);
		}
	}

	void FireBullet()
	{
		Instantiate (bullet, transform.position,
		             Quaternion.identity);
		if (Vector3.Distance(transform.position,player.transform.position)>= 50)
		{
			// invoke firing per time
			CancelInvoke ("FireBullet");
			isfiring = false;
		}
	}
	void OnTriggerEnter(Collider coll)
	{
		GameObject obj = coll.gameObject;

		if (obj.tag == "bullet P")
		{
			//Destroy eneme
			Destroy (gameObject);
		}
		if (obj.tag == "maze")
		{
			//Destroy eneme
			Destroy (gameObject);
		}
	}

}
