using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class TargetCollision : MonoBehaviour {
	
	bool beenHitten = false;
	Animation rootAnim;
	public AudioClip hitSound;
	public AudioClip resetSound;
	public int ID;
	public float resetTime = 3.0f;
	
	void Start()
	{
		rootAnim = transform.parent.transform.parent.animation;
	}
	
	void OnCollisionEnter(Collision coll)
	{
		if(!beenHitten && coll.gameObject.tag == "Coconut")
		{
			StartCoroutine("targetHit");
		}
	}
	
	IEnumerator targetHit()
	{
		winStateChecker.checker.states[ID] = true;
		Debug.Log(ID);
		if(winStateChecker.checker.checkState())
		{
			transform.root.gameObject.SendMessage("GetGift");
		}
		rootAnim.Play("down");
		audio.PlayOneShot(hitSound);
		beenHitten = true;
		
		yield return new WaitForSeconds(resetTime);
		
		winStateChecker.checker.states[ID] = false;
		beenHitten = false;
		audio.PlayOneShot(resetSound);
		rootAnim.Play("up");
	}
}
