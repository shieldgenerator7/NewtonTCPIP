using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelTract : MonoBehaviour {


	//persistant data that follows the player. 
	//Change in the menu and utalize in the random stage.
	public int RandomLevelStages;
	public LevelManager lvmgr;

	void Start(){
		RandomLevelStages = 5;
		GameObject mgr = GameObject.Find ("GameManager");
		lvmgr = mgr.GetComponent <LevelManager>();


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
		lvmgr.RandomLevelStageNumber++;
		//add code to show the stage level
		if (lvmgr.RandomLevelStageNumber > 100)
			lvmgr.RandomLevelStageNumber = 100;
	}

	void decreaseStage(){
		lvmgr.RandomLevelStageNumber--;
		if (lvmgr.RandomLevelStageNumber < 1)
			lvmgr.RandomLevelStageNumber = 1;
	}
}
