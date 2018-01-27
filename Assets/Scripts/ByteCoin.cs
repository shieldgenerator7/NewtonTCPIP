using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByteCoin : MonoBehaviour {

    public static int valueCollected = 0;//the total value collected

    int value = 1;//how many squares of the bg picture this byte coin restores

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            valueCollected += value;
            Destroy(gameObject);
        }
    }
}
