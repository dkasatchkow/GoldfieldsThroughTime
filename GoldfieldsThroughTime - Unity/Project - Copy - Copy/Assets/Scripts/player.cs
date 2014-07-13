using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public float bulletSpeed = 15000f;
	public float speed = 0.6f;
	public float sneekspeed = 0.3f;
	public float sprintspeed = 1.6f;
	public float sneek = -0.5f;
	public float FallSpeed = 0.1f;
	public float Falllevel = -0.0f;
	public GameObject bulletPrefab;
	public GameObject myCam;


	static public float FallSpeed2 = 0.1f;
	static public float sprintspeed2 = 2.6f;
	static public float speed2 = 0.6f;
	static public float Falllevel2 = -0.0f;
	private GUIText scoreText;
	private GUIText HPText;
	private int SneekTime = 5;

//	private Transform firePosition;
	static public bool isRunDown = false;
	static public bool isSpaceDown = false;
	//private float Fallupspeed = 0.01f;
	// Use this for initialization
	void Awake()
	{
		// tell all scripts that require it about this instances network view
		// Shooting
		gameObject.GetComponent<Shooting> ().myNetworkView = networkView;

		// 3
		if (!networkView.isMine)
		{
			enabled = false;
			myCam.camera.enabled = false;
		}
	}
	void Start () {
		scoreText = GameObject.Find ("Score").guiText;
		HPText = GameObject.Find ("HP").guiText;
		speed2 = speed;
		sprintspeed2 = sprintspeed;
		FallSpeed2 = FallSpeed;
		Falllevel2 = Falllevel;
//		firePosition = 

	}

	void FixedUpdate () {
			// 1.1 - uncomment for part 1.1
		if (networkView.isMine)
		{
			//Kill/R.S.P
			if (StaticVariables.HP < 0)
			{
				//reset HP
				StaticVariables.HP = StaticVariables.MAXHP;
				StaticVariables.lives -= 1;
				transform.position = new Vector3(400,5,300);
				FallSpeed2 = FallSpeed;
				Falllevel2 = Falllevel;
				speed2 = speed;
				sprintspeed2 = sprintspeed;
				StaticVariables.isSneekDown = false;
				StaticVariables.score = 1000;
				//reset game
				if (StaticVariables.lives < 0)
				{
					StaticVariables.score = 1000;
					StaticVariables.lives = 5;
					//transform.position = new Vector3(0,5,0);
				}
			}
			//HPText Update
			HPText.text = "HP " + StaticVariables.HP.ToString();
			//scoreText Update
			scoreText.text = "SP " + StaticVariables.score.ToString();
			//enege regen
			if (StaticVariables.score < 1000)
			{
				//if ((StaticVariables.isSneekDown == false)&&(isSpaceDown == false))
				//	StaticVariables.score += 2;
			}
//			if (StaticVariables.score < 0)
//				StaticVariables.score += 1;
			//if(Input.GetButtonDown("Fire1"))
//			if(Input.GetButtonDown("Fire1"))
//			{
//				print ("1");
//				if (StaticVariables.isSneekDown == false)
//				{
//					if (player.isRunDown == false)
//					{
//						if (StaticVariables.score > 50)
//						{
//							print ("2");
//							Rigidbody bulletInstance = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation) as Rigidbody;
//							bulletInstance.AddForce(firePosition.forward * bulletSpeed);
//							//-enege
//							StaticVariables.score -= 50;
//						}
//					}
//				}
//			}
			//Esc
			if (Input.GetKey (KeyCode.Escape))
							Application.Quit ();
			//key W
			if (Input.GetKey (KeyCode.UpArrow))
			{
				transform.Translate (0, 0, speed2);
				//key sprint
				if (Input.GetKey (KeyCode.RightShift))
				{
					if ((StaticVariables.score >= 0)&&(StaticVariables.isSneekDown == false))
					{
						StaticVariables.score -= 0;
						transform.Translate (0, 0, sprintspeed2);
						isRunDown = true;
					}
				}
			}
			if (Input.GetKey (KeyCode.W))
			{
				transform.Translate (0, 0, speed2);
				//key sprint
				if (Input.GetKey (KeyCode.LeftShift))
				{
					if ((StaticVariables.score >= 0)&&(StaticVariables.isSneekDown == false))
					{
						StaticVariables.score -= 0;
						transform.Translate (0, 0, sprintspeed2);
						isRunDown = true;
					}
				}
			}
			//reset sprint
			if (Input.GetKeyUp (KeyCode.LeftShift))
				isRunDown = false;
			if (Input.GetKeyUp (KeyCode.RightShift))
				isRunDown = false;


				
			//key S
			if (Input.GetKey (KeyCode.DownArrow))
				transform.Translate (0, 0, -speed2);
			if (Input.GetKey (KeyCode.S))
				transform.Translate (0, 0, -speed2);
			//key A
			if (Input.GetKey (KeyCode.LeftArrow))
				transform.Translate (-speed2, 0, 0);
			if (Input.GetKey (KeyCode.A))
				transform.Translate (-speed2, 0, 0);
			//key D
			if (Input.GetKey (KeyCode.RightArrow))
				transform.Translate (speed2, 0, 0);
			if (Input.GetKey (KeyCode.D))
				transform.Translate (speed2, 0, 0);

			//sneek
			/*if (Input.GetKeyDown (KeyCode.E))
			{
				if ((StaticVariables.isSneekDown == false)&&(StaticVariables.score >= 50))
				{
					//transform.Translate (0, sneek, 0);
					StaticVariables.score -= 50;
					Falllevel2 = sneek;
					speed2 = sneekspeed;
					sprintspeed2 = 0.0f;
					StaticVariables.isSneekDown = true;
				}
				else
				{
					Falllevel2 = Falllevel;
					speed2 = speed;
					sprintspeed2 = sprintspeed;
					StaticVariables.isSneekDown = false;
					StaticVariables.score -= 50;
				}
			}

			if (StaticVariables.isSneekDown == true)
			{
				if (SneekTime <= 0)
				{
					if (StaticVariables.score == 0)
					{
						Falllevel2 = Falllevel;
						speed2 = speed;
						sprintspeed2 = sprintspeed;
						StaticVariables.isSneekDown = false;
						StaticVariables.score -= 50;
					}
					else 
					{
						SneekTime += 5;
						StaticVariables.score -= 1;
					}
				}
				else SneekTime -= 1;
			}
			*/


			/*if (Input.GetKeyDown (KeyCode.LeftShift))
			{
				//transform.Translate (0, sneek, 0);
				Falllevel2 = sneek;
				speed2 = sneekspeed;
				sprintspeed2 = 0.0f;
				StaticVariables.isSneekDown = true;
			}
			if (Input.GetKeyUp (KeyCode.RightShift))
			{
				//transform.Translate (0, -sneek, 0);
				Falllevel2 = Falllevel;
				speed2 = speed;
				sprintspeed2 = sprintspeed;
				StaticVariables.isSneekDown = false;
			}
			if (Input.GetKeyUp (KeyCode.LeftShift))
			{
				//transform.Translate (0, -sneek, 0);
				Falllevel2 = Falllevel;
				speed2 = speed;
				sprintspeed2 = sprintspeed;
				StaticVariables.isSneekDown = false;
			}*/

			//jump/fly
			if (Input.GetKeyDown (KeyCode.Space))
			{
				FallSpeed2 = -0.2f;
				transform.Translate (0, 0.3f, 0);
				Falllevel2 = Falllevel;
				speed2 = speed;
				sprintspeed2 = sprintspeed;
				StaticVariables.isSneekDown = false;
				isSpaceDown = true;
			}
			if (Input.GetKeyUp (KeyCode.Space))
			{
				FallSpeed2 = FallSpeed;
				isSpaceDown = false;
			}
			//fly MP drane
			//if (isSpaceDown == true)
			//	StaticVariables.score -= 4;
			//stop fly
			//if (StaticVariables.score <= 4)
			//{
			//	FallSpeed2 = FallSpeed;
			//	isSpaceDown = false;
			//}
			


			//FallSpeed
			if (transform.position.y > Falllevel2 )
			{
				transform.Translate (0, -FallSpeed2, 0);
			}
			if (transform.position.y < Falllevel2 )
			{
				transform.Translate (0, FallSpeed2, 0);
			}
		}
	}
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		// drag the script (by component name) into the Observed field to make this happen.
		// stream.isWriting checks for the owner of this script attached to the object
		// if it's the server's version of the cube then stream.isWriting is true
		if (stream.isWriting)
		{
			Vector3 pos = transform.position;
			stream.Serialize(ref pos);
		}
		else
		{
			// otherwise we are the client just observing it.
			// This says if you are not the owner (so everyone besides the server), 
			// create a variable that stores a position (initially set to 0). 
			// The stream.Serialize on this side of the else does the opposite for clients. 
			// Instead of sending the data out like it does for the owner (server), 
			// it receives data from the network. It sets the position of the cube equal
			// to the data that it receives.
			Vector3 receivedPosition = Vector3.zero;
			stream.Serialize(ref receivedPosition);
			transform.position = receivedPosition;
		}
	}
}
