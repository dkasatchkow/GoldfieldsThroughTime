using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	private GameObject player;
	private GUIText scoreText;
	public float bulletSpeed = 10;
	public bool Destroybollet = false;
	public float timeOut = 3.0f;

	// Use this for initialization
	void Start ()
	{
		scoreText = GameObject.Find ("Score").guiText;
		player = GameObject.Find ("Player");
		// set timeout
		Invoke ("Kill", timeOut);

		// move toward player
//		transform.LookAt (player.transform.position);
//		transform.position += transform.forward * bulletSpeed *
//			Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
	
	void OnTriggerEnter(Collider coll)
	{
		GameObject obj = coll.gameObject;
		
		//if (obj.tag == "enemes")
		//{
			//StaticVariables.score += 1;

			//scoreText.text = "Score " + StaticVariables.score.ToString();

			//if (Destroybollet == true)
			//{
				//Destroy bullet
			//	Destroy (gameObject);
			//}
		//}
		if (obj.tag == "maze")
		{
			//Destroy bullet
			Destroy (gameObject);
		}
		if (obj.tag == "bullet E")
		{
			if (Destroybollet == true)
			{
				//Destroy bullet
				Destroy (gameObject);
			}
		}
	}

	void Kill()
	{
		Destroy (gameObject);
	}
}
