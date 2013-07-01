using UnityEngine;
using System.Collections;

public class textHints : MonoBehaviour {
	
	float timer = 0.0f;
	
	void Update()
	{
		if(guiText.enabled)
		{
			timer += Time.deltaTime;
		}
		if(timer >= 3)
		{
			guiText.enabled = false;
			timer = 0.0f;
		}
	}
	
	void ShowHint(string message)
	{
		guiText.text = message;
		if(!guiText.enabled)
		{
			guiText.enabled = true;
		}
	}
}