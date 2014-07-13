using UnityEngine;
using System.Collections;

public class HPbox : MonoBehaviour {

	private GUIText HPText;
	public int addHP = 100;
	public int addmaxHP = 0;

	// Use this for initialization
	void Start () {
		HPText = GameObject.Find ("HP").guiText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll)
	{
		GameObject obj = coll.gameObject;
		
		if (obj.tag == "Player")
		{
			StaticVariables.HP += addHP;
			StaticVariables.MAXHP += addmaxHP;

			if (StaticVariables.HP > StaticVariables.MAXHP)
			{
				StaticVariables.HP = StaticVariables.MAXHP;
			}

			HPText.text = "HP " + StaticVariables.HP.ToString();

			//obj.transform.position = new Vector3(0,5,0);
			Destroy (gameObject);
		}
	}
}
