using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour {

    /// <summary>
    /// The level that should be loaded after this ends.
    /// Leave it 0 to automatically go to the next one
    /// </summary>
    public int nextLevelNumber = 0;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (nextLevelNumber == 0)
            {
                LevelManager.LoadNextLevel();
            }
            else
            {
                LevelManager.LoadLevel(nextLevelNumber);
            }
        }
    }
}
