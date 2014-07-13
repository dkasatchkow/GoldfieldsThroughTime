using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	private GUIText scoreText;
	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find ("Score").guiText;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "SP " + StaticVariables.score.ToString();
	}
}
