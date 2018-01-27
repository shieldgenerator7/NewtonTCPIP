using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject playerObject;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = gameObject.transform.position - playerObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(
            transform.position,
            playerObject.transform.position + offset,
            10);
	}
}
