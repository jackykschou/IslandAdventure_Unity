using UnityEngine;
using System.Collections;

public class PowerCell : MonoBehaviour {
	
	float rotationSpeed = 100f;
	
	void Update () 
	{
		
		transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
	}
	
	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			coll.gameObject.SendMessage("PickupCell");
			Destroy(gameObject);
		}
	}
}
