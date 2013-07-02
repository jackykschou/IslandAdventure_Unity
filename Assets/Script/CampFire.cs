using UnityEngine;
using System.Collections;

public class CampFire : MonoBehaviour {

	public GUITexture matchGUI;
	ParticleSystem[] fireEmitter;
	public GUIText textHint;
	bool lightened = false;
	
	public void StartFire()
	{
		if(matchGUI.enabled)
		{
			fireEmitter = GetComponentsInChildren<ParticleSystem>();
			foreach(ParticleSystem system in fireEmitter)
			{
				system.Play();
			}
			audio.Play();
			matchGUI.enabled = false;
			lightened = true;
		}
		else if(!lightened)
		{
			textHint.SendMessage("ShowHint", "I need to lighen the fire...");
		}
	}
}
