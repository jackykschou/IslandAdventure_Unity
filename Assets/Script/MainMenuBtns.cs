using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class MainMenuBtns : MonoBehaviour {
	
	public Texture2D normalTexture;
	public Texture2D rollOverTexture;
	public AudioClip beep;
	public bool quitButton;
	public string levelToLoad;
	
	void OnMouseEnter()
	{
		guiTexture.texture = rollOverTexture;
	}
	
	void OnMouseExit()
	{
		guiTexture.texture  = normalTexture;
	}
	
	IEnumerator OnMouseUp()
	{
		audio.PlayOneShot(beep);
		yield return new WaitForSeconds(0.5f);
		if(quitButton)
		{
			Application.Quit();
		}
		else
		{
			Application.LoadLevel(levelToLoad);
		}
	}
}
