using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {
	
	bool doorIsOpen = false;
	float doorTimer = 0f;
	public float doorOpenTime = 3.0f;
	public AudioClip doorOpenSound;
	public AudioClip doorCloseSound;
	
	void Update () 
	{
		if(doorIsOpen)
		{
			doorTimer += Time.deltaTime;
		}
		if(doorTimer >= doorOpenTime)
		{
			DoorOperation(false, "doorclose", doorCloseSound);
			doorTimer = 0f;
		}
	}
	
	void DoorCheck()
	{
		if(!doorIsOpen)
		{
			DoorOperation(true, "dooropen", doorOpenSound);
		}
	}
	
	void DoorOperation(bool isOpen, string animeName, AudioClip sound)
	{
		audio.PlayOneShot(sound);
		transform.parent.animation.Play(animeName);
		doorIsOpen = isOpen;
	}
}
