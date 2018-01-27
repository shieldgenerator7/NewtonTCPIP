using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointChecker : MonoBehaviour {

    public static CheckpointChecker currentCP;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentCP = this;
        }
    }

    public static void respawnPlayer(GameObject go)
    {
        go.transform.position = currentCP.gameObject.transform.position;
    }
}
