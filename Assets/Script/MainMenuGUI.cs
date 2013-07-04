using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class MainMenuGUI : MonoBehaviour {

	public AudioClip beep;
	public GUISkin skin;
	public Rect menuArea;
	public Rect playButton;
	public Rect instructButton;
	public Rect quitButton;
	public Rect instructions;
	bool isMainPage = true;
	bool isInstructionPage = false;
	Rect menuAreaNormalized;
	
	void Start()
	{
		menuAreaNormalized = new Rect(menuArea.x * Screen.width - (menuArea.width * 0.5f), menuArea.y * Screen.height - (menuArea.height * 0.5f), 
			menuArea.width, menuArea.height);	
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		GUI.BeginGroup(menuAreaNormalized);
		
		if(isMainPage)
		{
			if(Application.CanStreamedLevelBeLoaded("Island"))
			{
				if(GUI.Button(playButton, "Play"))
				{
					StartCoroutine("ButtonAction", "Play");
				}
			}
			else{
					float loadPercent = Application.GetStreamProgressForLevel(1) * 100;
					GUI.Box(new Rect(playButton), "Loading..." + loadPercent.ToString("f0") + "%");	
				}
			if(GUI.Button(instructButton, "Instructions"))
			{
				StartCoroutine("ButtonAction", "Instructions");
			}
			if(Application.platform != RuntimePlatform.OSXWebPlayer && Application.platform != RuntimePlatform.WindowsWebPlayer && GUI.Button(quitButton, "Quit"))
			{
				StartCoroutine("ButtonAction", "Quit");
			}
		}
		else if(isInstructionPage)
		{
			GUI.Label(new Rect(instructions), "You are lost in an island... You mission is to get yourself out of there. Signal people to help you! \nPress E to collect Item and interact with objects");
			if(GUI.Button(quitButton, "Quit"))
			{
				audio.PlayOneShot(beep);
				isMainPage = true;
				isInstructionPage = false;
			}
		}
		
		GUI.EndGroup();
	}
	
	IEnumerator ButtonAction(string buttonName)
	{
		audio.PlayOneShot(beep);
		
		yield return new WaitForSeconds(0.3f);
		
		if(buttonName == "Play")
		{
			Application.LoadLevel("Island");
		}
		else if(buttonName == "Instructions")
		{
			isInstructionPage = true;
			isMainPage = false;
		}
		else if(buttonName == "Quit")
		{
			Application.Quit();
		}
	}
}
