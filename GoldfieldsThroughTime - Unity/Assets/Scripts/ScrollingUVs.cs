using UnityEngine;
using System.Collections;

public class ScrollingUVs : MonoBehaviour {

	public Vector2 Scroll = new Vector2 (0.05f , 0.05f);
	Vector2 Offset = new Vector2 (0f, 0f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Offset +=  Scroll * Time.deltaTime;
		renderer.material.SetTextureOffset ("_MainTex", Offset);
	}
}
