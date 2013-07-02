using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class CoconutWin : MonoBehaviour {

	public static bool won = false;
	public AudioClip victorySound;
	public GameObject cellPrefab;
	public static int downTargets = 0;
	//WinStateClass states = new WinStateClass(); //for another approach
	
	void Update()
	{
		/**for another approach
		GameObject.Find("t1").SendMessage("GetDownState", states);
		GameObject.Find("t2").SendMessage("GetDownState", states);
		GameObject.Find("t3").SendMessage("GetDownState", states);
		*/
		if(downTargets >= 4 && !won)
		{
			audio.PlayOneShot(victorySound);
			won = true;
			GameObject gift = transform.Find("powerCell").gameObject;
			gift.transform.Translate(-1, 0, 0);
			Instantiate(cellPrefab, gift.transform.position, transform.rotation);
			Destroy(gift);
		}
			
			
	}
	
}
