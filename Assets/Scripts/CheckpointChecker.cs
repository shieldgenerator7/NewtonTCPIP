using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointChecker : MonoBehaviour {

    /// <summary>
    /// Set this to true to have Newton start here
    /// </summary>
    public bool startCheckPoint = false;

    public static CheckpointChecker currentCP;

	// Use this for initialization
	void Start () {
		if (startCheckPoint)
        {
            currentCP = this;
            respawnPlayer(GameObject.FindGameObjectWithTag("Player"));
        }
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
        go.GetComponent<PlayerController>().rideSnail(null, false);
        foreach(SnailController sc in FindObjectsOfType<SnailController>())
        {
            sc.playerRiding = false;
        }
        foreach (Transform t in go.transform)
        {
            if (t.gameObject.CompareTag("Enemy"))
            {
                Destroy(t.gameObject);
            }
        }
    }
}
