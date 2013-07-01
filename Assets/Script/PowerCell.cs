using UnityEngine;
using System.Collections;

public class PowerCell : MonoBehaviour {
	
	float rotationSpeed = 100f;
	
	void Update () 
	{
		transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
		/**some bugs due to random behavior of first personal controller
		if(Input.GetKeyDown(KeyCode.E) && pickable)
		{
			player.SendMessage("CellPickUp");
			Destroy(gameObject);
		}
		*/
	}
	
	void Picked ()
	{
		Destroy(gameObject);
	}
	
	/** some bugs due to random behavior of first personal controller
	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			pickable = true;
			player = coll;
		}
	}
	
	void onTriggerExit(Collider coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			pickable = false;
			player = null;
		}
	}
	*/
}
