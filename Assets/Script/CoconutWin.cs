using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class CoconutWin : MonoBehaviour {

	public static bool won = false;
	public AudioClip victorySound;
	public GameObject cellPrefab;
	public static int downTargets = 0;
	
	void GetGift()
	{
		if(!won)
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
