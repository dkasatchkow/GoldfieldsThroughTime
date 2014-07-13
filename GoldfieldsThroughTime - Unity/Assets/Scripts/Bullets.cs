using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour
{
	private GameObject player;
	private GUIText HPText;
	private GUIText scoreText;
	private float Falllevel = 0.5f;
	private float FallSpeed = 0.1f;
	public float bulletSpeed = 10;
	public int bollDam = 90;
	public bool Destroybollet = false;
	public float timeOut = 3.0f;

	public float speedY = 0;
	public float speedX = 0;
	public float speedZ = 0;
	
	// Use this for initialization
	void Start ()
	{
		HPText = GameObject.Find ("HP").guiText;
		scoreText = GameObject.Find ("Score").guiText;
		player = GameObject.Find ("Player");
		// set timeout
		Invoke ("Kill", timeOut);

		// look toward player
//		transform.LookAt (player.transform.position);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//move
		//transform.position += new Vector3 (speedX * Time.deltaTime, speedY * Time.deltaTime, speedZ * Time.deltaTime);

		// move toward player
		transform.position += transform.forward * bulletSpeed *
			Time.deltaTime;

		//level
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

	void OnTriggerEnter(Collider coll)
	{
		GameObject obj = coll.gameObject;
		
		if (obj.tag == "Player")
		{
			StaticVariables.HP -= bollDam;

			/*if (StaticVariables.HP < 1)
			{
				//reset HP
				StaticVariables.HP = StaticVariables.MAXHP;
				StaticVariables.lives -= 1;
				//reset game
				if (StaticVariables.lives < 0)
				{
					StaticVariables.score = 0;
					StaticVariables.lives = 5;
				}
				obj.transform.position = new Vector3(0,5,0);
			}
			HPText.text = "HP " + StaticVariables.HP.ToString();
			scoreText.text = "Score " + StaticVariables.score.ToString();
*/
			if (Destroybollet == true)
			{
				//Destroy bullet
				Destroy (gameObject);
			}
		}
		if (obj.tag == "maze")
		{
			//Destroy bullet
			Destroy (gameObject);
		}
		if (obj.tag == "bullet P")
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

