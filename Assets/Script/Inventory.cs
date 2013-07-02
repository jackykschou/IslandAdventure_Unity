using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public static int charge = 0;
	public AudioClip collectSound;
	public Texture2D[] hudCharge;
	public GUITexture chargeHudGUI;
	public Texture2D[] meterCharge;
	public GUITexture matchGUI;
	public Renderer meter;
	
	void Start () {
		charge = 0;
	}
	
	void Update()
	{
		RaycastHit hit;;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f));
		if(Physics.Raycast(ray, out hit, 1.5f))
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				if(hit.transform.tag == "cell")
				{
					CellPickUp();
					hit.transform.SendMessage("Picked");
				}
				else if(hit.transform.tag == "matches")
				{
					MatchesPickUp();	
					hit.transform.SendMessage("Picked");
				}
				else if(hit.transform.tag == "firecamp")
				{	
					hit.transform.SendMessage("StartFire");
				}
			}
		}
	}
	
	void CellPickUp()
	{
		HUDon();
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		charge++;
		chargeHudGUI.texture = hudCharge[charge];
		meter.material.mainTexture = meterCharge[charge];
	}
	
	void MatchesPickUp()
	{
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		matchGUI.enabled = true;
	}
	
	void HUDon()
	{
		if(!chargeHudGUI.enabled)
		{
			chargeHudGUI.enabled = true;
		}
	}
}
