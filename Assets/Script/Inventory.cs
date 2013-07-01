using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public static int charge = 0;
	public AudioClip collectSound;
	public Texture2D[] hudCharge;
	public GUITexture chargeHudGUI;
	public Texture2D[] meterCharge;
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
			if(Input.GetKeyDown(KeyCode.E) && hit.transform.tag == "cell")
			{
				CellPickUp();
				hit.transform.SendMessage("Picked");
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
	
	void HUDon()
	{
		if(!chargeHudGUI.enabled)
		{
			chargeHudGUI.enabled = true;
		}
	}
}
