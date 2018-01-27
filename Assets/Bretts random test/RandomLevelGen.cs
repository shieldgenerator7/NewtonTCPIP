using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;


public class RandomLevelGen : MonoBehaviour {

	GameObject startPos;
	int ObsticalNumber = 20;
	float spacer = .6f;
//	float holdPos = 0f;
	Vector3 holdPos;
	public GameObject endPos;

	public GameObject[] theObsticals = new GameObject[4];

	public GameObject tempBox;

	int tracker=0;

	void Start () {
		
		startPos = GameObject.Find ("StartPos");
		holdPos = startPos.transform.position;
		MixLevel ();

	}

	void MixLevel(){
		int randomThing;
		Vector3 tempPos = holdPos;
		GameObject theObstical;

		for (int i = 0; i < ObsticalNumber; i++) {
			Debug.Log (holdPos);
			randomThing = Random.Range (0, 4);
	//		tempPos = new Vector3 (holdPos, 0, 0);
			theObstical = theObsticals [randomThing];
			Instantiate (theObstical, tempPos, Quaternion.identity);
		
		//	holdPos = transform.InverseTransformPoint(theObstical.transform.Find ("exitPoint").transform.localPosition);
			holdPos = theObstical.transform.Find ("exitPoint").transform.position;
			tempPos = tempPos + holdPos;


			tempPos = new Vector3 (tempPos.x + spacer, tempPos.y, 0);
	//		holdPos = exitPos.transform.position;
	//		exitPos = theObstical.GetComponentsInChildren<exitPoint>;
	//		holdPos = myPos.transform.position;
			//Instantiate (theObsticals[randomThing], tempPos, Quaternion.identity);
			//holdPos = holdPos + spacer;





		}
		Instantiate (endPos, tempPos, Quaternion.identity);
	}
}
