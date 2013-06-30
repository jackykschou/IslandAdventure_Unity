using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {
	
	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			transform.FindChild("door").SendMessage("DoorCheck");	
		}
	}
	
}
