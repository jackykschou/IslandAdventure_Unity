using UnityEngine;
using System.Collections;

/**version two (raycast)
public class PlayerCollisions : MonoBehaviour {
	
	GameObject currentDoor;
	RaycastHit hit;
	
	void Update()
	{
		if (Physics.Raycast(transform.position, transform.forward, out hit, 3))
		{
			if(hit.collider.gameObject.tag == "openableDoor")
			{
				currentDoor = hit.collider.gameObject;
				currentDoor.SendMessage("DoorCheck"); 	
			}
		}
	}
			
}
**/

/** version one (collision detection)
public class PlayerCollisions : MonoBehaviour {
	
	bool doorIsOpen = false;
	float doorTimer = 0f;
	GameObject CurrentDoor;
	public float doorOpenTime = 3.0f;
	public AudioClip doorOpenSound;
	public AudioClip doorCloseSound;
	
	void Start () 
	{
	
	}
	
	void Update () 
	{
		if(doorIsOpen)
		{
			doorTimer += Time.deltaTime;
		}
		if(doorTimer >= doorOpenTime)
		{
			DoorOperation(CurrentDoor, false, "doorclose", doorCloseSound);
			doorTimer = 0f;
		}
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.tag == "openableDoor" && !doorIsOpen)
		{
			CurrentDoor = hit.gameObject;
			DoorOperation(hit.gameObject, true, "dooropen", doorOpenSound);
		}
	}
	
	void DoorOperation(GameObject door, bool isOpen, string animeName, AudioClip sound)
	{
		door.audio.PlayOneShot(sound);
		door.transform.parent.animation.Play(animeName);
		doorIsOpen = isOpen;
	}
}
**/
