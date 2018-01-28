using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityEngine.SceneManagement;


public class RandomLevelGen : MonoBehaviour {

	GameObject startPos;
	int ObsticalNumber = 20;
	float spacer = .6f;				// this will need to be more dynamic based on next platform
	Vector3 holdPos;
	public GameObject endPos;


	int platformCount = 0;
	public static GameObject[] theObsticals;

	public GameObject tempBox;

	int tracker=0;
	public LevelManager lvmgr;


	void Start () {
		GameObject mgr = GameObject.Find ("GameManager");
		lvmgr = mgr.GetComponent <LevelManager>();

		theObsticals = Resources.LoadAll<GameObject> ("RandomPlatformSegment");
		startPos = GameObject.Find ("StartPos");
		holdPos =  new Vector3(startPos.transform.position.x+spacer,.2f,0); // starting segment

		MixLevel ();

	}

	void MixLevel(){
		int randomThing;
		Vector3 tempPos = holdPos;
		GameObject theObstical;
		GameObject tempObj;

		for (int i = 0; i < lvmgr.RandomLevelStageNumber; i++) {
			randomThing = Random.Range (0, theObsticals.Length);
	//		tempPos = new Vector3 (holdPos, 0, 0);
			theObstical = theObsticals [randomThing];
			tempObj = Instantiate (theObstical, tempPos, Quaternion.identity);
		
		//	holdPos = transform.InverseTransformPoint(theObstical.transform.Find ("exitPoint").transform.localPosition);
			holdPos = theObstical.transform.Find ("exitPoint").transform.position;

			SceneManager.MoveGameObjectToScene (tempObj,SceneManager.GetSceneByName("RandomLevel"));

			tempPos = tempPos + holdPos;


		tempPos = new Vector3 (tempPos.x + spacer, tempPos.y, 0);
	//		holdPos = exitPos.transform.position;
	//		exitPos = theObstical.GetComponentsInChildren<exitPoint>;
	//		holdPos = myPos.transform.position;
			//Instantiate (theObsticals[randomThing], tempPos, Quaternion.identity);
			//holdPos = holdPos + spacer;





		}
		tempObj = Instantiate (endPos, tempPos, Quaternion.identity);
		SceneManager.MoveGameObjectToScene (tempObj,SceneManager.GetSceneByName("RandomLevel"));
	}	
}
