using UnityEngine;
using System.Collections;

public class TP1 : MonoBehaviour {

	public float posX = 0;
	public float posY = 0;
	public float posZ = 0;
	public float posX2 = 0;
	public float posY2 = 0;
	public float posZ2 = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider coll)
	{
		GameObject obj = coll.gameObject;
		
		if (obj.tag == "Player")
		{
			obj.transform.position = new Vector3(0f,0f,0f);
			obj.rigidbody.velocity = new Vector3(0,0,0);
			obj.transform.position = new Vector3(posX,posY,posZ);
		}
	}
}
