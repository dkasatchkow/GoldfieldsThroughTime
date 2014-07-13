using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {
	
	
	public Transform cubePrefab;
	
	void OnServerInitialized()
	{
		SpawnPlayer();
		
	}
	void OnConnectedToServer()
	{
		SpawnPlayer();
	}
	
	void SpawnPlayer()
	{
		Transform myTransform = (Transform)Network.Instantiate(cubePrefab, transform.position, transform.rotation, 0);
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
