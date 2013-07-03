using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class WinGame : MonoBehaviour {

	public GameObject winSequence;
	public GUITexture fader;
	public AudioClip winSound;
	
	IEnumerator GameOver()
	{
		AudioSource.PlayClipAtPoint(winSound, transform.position);
		Instantiate(winSequence);
		
		yield return new WaitForSeconds(5.0f);
		
		Instantiate(fader);
	}
}
