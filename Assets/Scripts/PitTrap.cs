using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitTrap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().respawn();
        }
    }
}
