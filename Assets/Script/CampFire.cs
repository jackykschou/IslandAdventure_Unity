using UnityEngine;
using System.Collections;

public class CampFire : MonoBehaviour {

	public GUITexture matchGUI;
	ParticleSystem[] fireEmitter;
	public GUIText textHint;
	
	public void StartFire()
	{
		fireEmitter = GetComponentsInChildren<ParticleSystem>();
		foreach(ParticleSystem system in fireEmitter)
		{
			system.Play();
		}
		audio.Play();
	}
	
	public void ShowHint()
	{
		textHint.SendMessage("ShowHint", "I need to lighen the fire...");
	}
}
