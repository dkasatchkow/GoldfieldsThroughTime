using UnityEngine;
using System.Collections;

public class MazeEnergyWall : MonoBehaviour 
{
	private GUIText HPText;
	private GUIText scoreText;
	private bool playerKolide = false;
	public int bollDam = 1;
	
	// Use this for initialization
	void Start ()
	{
		HPText = GameObject.Find ("HP").guiText;
		scoreText = GameObject.Find ("Score").guiText;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerKolide == true)
			StaticVariables.HP -= bollDam;
	}
	void OnTriggerEnter(Collider coll)
	{
		GameObject obj = coll.gameObject;
		
		if (obj.tag == "Player")
		{

			playerKolide = true;
			HPText.text = "HP " + StaticVariables.HP.ToString();
			player.FallSpeed2 = 0.3f;
			player.Falllevel2 = -10.0f;
			player.speed2 = 0.1f;
			player.sprintspeed2 = 0.1f;
			StaticVariables.isSneekDown = true;
		}
	}
	void OnTriggerExit(Collider coll)
	{
		playerKolide = false;
	}
}
