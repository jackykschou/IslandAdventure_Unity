using UnityEngine;
using System.Collections;

public class ThrowTrigger : MonoBehaviour {
	
	public GUIText textHint;
	public GUITexture crosshair;
	
	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "Player")
		{
			CoconutThrower.throwable = true;
			crosshair.enabled = true;
			if(!CoconutWin.won)
			{
				textHint.SendMessage("ShowHint", "\n\n\nLooks like we need the battery");
			}
		}
	}
	
	void OnTriggerExit(Collider coll)
	{
		if(coll.tag == "Player")
		{
			crosshair.enabled = false;
			CoconutThrower.throwable = false;
		}
	}
}
