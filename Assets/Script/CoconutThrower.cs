using UnityEngine;
using System.Collections;
[RequireComponent (typeof (AudioSource))]

public class CoconutThrower : MonoBehaviour {
	
	public static bool throwable = false;
	
	public AudioClip throwSound;
	public Rigidbody coconutprefab;
	public float throwSpeed = 30.0f;
	
	void Update () {
		if(Input.GetButtonDown("Fire1") && throwable)
		{
			Rigidbody tempCoconut = Instantiate(coconutprefab, transform.position, transform.rotation) as Rigidbody;
			tempCoconut.name = "tempCoconut";
			if(tempCoconut.rigidbody == null)
			{
				tempCoconut.gameObject.AddComponent("Rigidbody");
			}
			tempCoconut.velocity = transform.forward * throwSpeed;
			Physics.IgnoreCollision(transform.root.collider, tempCoconut.collider, true);
			audio.PlayOneShot(throwSound);
		}
	}
}
