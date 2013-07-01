using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {
	
	public AudioClip lockedSound;
	public Light doorLight;
	public GUIText textHint;
	
	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			if(Inventory.charge == 4)
			{
				transform.FindChild("door").SendMessage("DoorCheck");
				if(GameObject.Find("PowerGUI"))
				{
					doorLight.color = Color.green;
					Destroy(GameObject.Find("PowerGUI"));
				}
			}
			else if(Inventory.charge > 0 && Inventory.charge < 4)
			{
				transform.FindChild("door").audio.PlayOneShot(lockedSound);
				textHint.SendMessage("ShowHint", "Opps, still not enough power...");
			}
			else
			{
				transform.FindChild("door").audio.PlayOneShot(lockedSound);
				textHint.SendMessage("ShowHint", "Power is needed to open the door...");
				coll.gameObject.SendMessage("HUDon");
			}
				
		}
		
	}
	
}
