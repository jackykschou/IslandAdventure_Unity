using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class TargetCollision : MonoBehaviour {
	
	bool beenHitten = false;
	Animation rootAnim;
	public AudioClip hitSound;
	public AudioClip resetSound;
	//public float resetTime = 3.0f; //used for subroutine approach
	float timeBetweenHit = 0.0f; //prevent immediate collision after one
	
	//public bool down = false; //for another approach
	
	void Start()
	{
		rootAnim = transform.parent.transform.parent.animation;
	}
	
	void Update()
	{
		if(beenHitten && timeBetweenHit >= 3.0f)
		{
			timeBetweenHit = 0;
			beenHitten = false;
			CoconutWin.downTargets--;
			audio.PlayOneShot(resetSound);
			rootAnim.Play("up");
		}
		else if(beenHitten)
		{
			timeBetweenHit += Time.deltaTime;
		}
	}
	
	void OnCollisionEnter(Collision coll)
	{
		if(!beenHitten && coll.gameObject.tag == "Coconut")
		{
			rootAnim.Play("down");
			audio.PlayOneShot(hitSound);
			beenHitten = true;
			CoconutWin.downTargets++;
			//StartCoroutine("targetHit");
		}
	}
	
	/**subroutine approach
	IEnumerator targetHit()
	{
		//down = true; //for another approach
		rootAnim.Play("down");
		audio.PlayOneShot(hitSound);
		beenHitten = true;
		//CoconutWin.downTargets++;
		
		yield return new WaitForSeconds(resetTime);
		
		//down = false; //for another approach
		beenHitten = false;
		CoconutWin.downTargets--;
		audio.PlayOneShot(resetSound);
		rootAnim.Play("up");
	}
	**/
	
	/**another approach for setting whether targets are down using class
	void GetDownState(WinStateClass states)
	{
		if(name == "t1")
		{
			states.T1Down = down;
		}
		else if(name == "t2")
		{
			states.T2Down = down;
		}
		else if(name == "t3")
		{
			states.T3Down = down;
		}
	}
	*/
	
}
