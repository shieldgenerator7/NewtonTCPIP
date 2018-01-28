using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelTract : MonoBehaviour {


	//persistant data that follows the player. 
	//Change in the menu and utalize in the random stage.
	public int RandomLevelStages;

	void Start(){
		RandomLevelStages = 5;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			string myJob = this.name;
			if (myJob == "Increase")
				increaseStage ();
			else if (myJob == "Decrease")
				decreaseStage ();
		}
	}


	void increaseStage(){
		RandomLevelStages = RandomLevelStages + 1; 
		//add code to show the stage level
	}

	void decreaseStage(){
		RandomLevelStages--;
	}
}
