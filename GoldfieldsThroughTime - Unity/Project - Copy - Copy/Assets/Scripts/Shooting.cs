using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public Transform firePosition;
    public float bulletSpeed;
	public NetworkView myNetworkView;


	void Update ()
    {
		if (myNetworkView.isMine)
		{
			//if(Input.GetButtonDown("Fire1"))
			if(Input.GetButtonDown("Fire1"))
	        {
				//if (StaticVariables.isSneekDown == false)
				//{
					//if (player.isRunDown == false)
					//{
						//if (StaticVariables.score > 100)
						//{
	        		    	Rigidbody bulletInstance = (Rigidbody)Network.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation,0) as Rigidbody;
	        		    	bulletInstance.AddForce(firePosition.forward * bulletSpeed);
							//-enege
							//StaticVariables.score -= 100;
						//}
	        		//}
				//}
			}
		}
    }
}