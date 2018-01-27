using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {

	Vector3 startEnd;
	Vector3 finishEnd;
	Vector3 myPos;
	float step = 1f;

	// Use this for initialization
	void Start () {
		myPos = this.transform.position;
		startEnd = new Vector3 (myPos.x - step, myPos.y, myPos.z);
		finishEnd = new Vector3 (myPos.x + step, myPos.y, myPos.z);

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(startEnd, finishEnd, Mathf.PingPong(Time.time, step));
	}
}
