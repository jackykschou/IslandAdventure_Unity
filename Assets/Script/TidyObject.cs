using UnityEngine;
using System.Collections;

public class TidyObject : MonoBehaviour {
	
	public float livingTime = 2.0f;
	
	void Start()
	{
		Destroy(gameObject, livingTime);
	}
	
	void OnCollisionEnter(Collision coll)
	{
		if(coll.transform.tag == "target")
		{
			Destroy(gameObject);	
		}
	}
}
