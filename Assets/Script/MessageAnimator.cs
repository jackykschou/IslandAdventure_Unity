using UnityEngine;
using System.Collections;

public class MessageAnimator : MonoBehaviour {

	public float speed = 1.0f;
	public float startXPos = -1.0f;
	public float endXPos = 0.5f;
	float startTime;
	
	void Start()
	{
		startTime = Time.time;	
	}
	
	void Update()
	{
		Vector3 pos = new Vector3(Mathf.Lerp(startXPos, endXPos, (Time.time - startTime) * speed), transform.position.y, transform.position.z);
		transform.position = pos;
	}
}
