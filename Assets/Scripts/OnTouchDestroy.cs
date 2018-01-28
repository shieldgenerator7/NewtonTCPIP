using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys the enemy script on an enemy
/// </summary>
public class OnTouchDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(GetComponent<Enemy>());
        }
    }
}
