using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{
	public GameObject player;
	//public Camera m_Camera;
	public bool flip = false;
	public Vector3 m_Axis;
	void Update()
	{
		//transform.LookAt(Camera.main.transform);
		transform.LookAt (player.transform.position);
		if (flip == true)
		{
			Quaternion rot = transform.rotation;
			rot.y += 180;
			Vector3 pos = transform.position;
			Vector3 axis = m_Axis;
			transform.RotateAround(pos,axis,180);
		}
	}
}