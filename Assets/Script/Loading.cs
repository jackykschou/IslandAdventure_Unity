using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {

	public GUITexture loading;
	
	void Load()
	{
		Instantiate(loading);
	}
}
