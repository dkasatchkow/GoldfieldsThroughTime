using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	// 2 used for RPCs
	Vector3 lastPosition;
	float minimumMovement = .05f;
	// Use this for initialization
	void Start () {
	
	}
	void Awake()
	{
		// 3
		if (!networkView.isMine)
			enabled = false;
	}
	// Update is called once per frame
	void Update () {
		// 1.1 - uncomment for part 1.1
		if (networkView.isMine)
		{
//			Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//			float speed = 5;
//			transform.Translate(speed * moveDir * Time.deltaTime);
		}

		// the code is setup to modify the transform of the cube, 
		// which is being observed by the network view so that 
		// whenever a change is detected it’s sent across the network.
		// it does this when we observe the cube
		// **** only the server is allowed to modify that position given those inputs.
		//if (Network.isServer) - uncomment for part 1 and 2
		//if (Network.isServer) // 2 and 1
//		if (networkView.isMine) // 3
//		{
//			Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//			float speed = 15;
//			transform.Translate(speed * moveDir * Time.deltaTime);

			// 2 - using RPC's
//			if (Vector3.Distance(transform.position, lastPosition) > minimumMovement)
//			{
//				lastPosition = transform.position;
//				networkView.RPC("SetPosition", RPCMode.Others, transform.position);
//			}


	//	}



	}
	// 2
	// another method that requires no state sychronisation is the use of Remote Procedure Calls [RPC]
//	[RPC]
//	void SetPosition(Vector3 newPosition)
//	{
//		transform.position = newPosition;
//	}


	// 1.2 and 3
	// uncomment to use Reliable Delta Compression (in the NetworkView State Synchronisation settings
	// and watch the script attached to the cube - the server will not change the movement of the cube
	// because it is controlling the cube - only the clients will be sent the change via serialisation
	// and move the cube then
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
