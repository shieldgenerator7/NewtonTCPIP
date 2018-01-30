using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitTrap : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().respawn();
        }
        if (other.gameObject && other.gameObject.CompareTag("Enemy"))
        {
            EnemyBOSS enemyBOSS = other.gameObject.GetComponent<EnemyBOSS>();
            if (enemyBOSS != null)
            {
                enemyBOSS.kill();
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
