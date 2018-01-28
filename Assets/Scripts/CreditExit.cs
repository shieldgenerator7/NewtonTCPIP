using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CreditExit : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			string myJob = this.name;
			if (SceneManager.GetSceneByName("CreditsScreen").isLoaded)
			{
				SceneManager.UnloadSceneAsync("CreditsScreen");
			}

			if (myJob == "MainMenu")
				LoadMenu ();

		}
	}

	void LoadMenu(){
		SceneManager.LoadScene ("MainMenu",LoadSceneMode.Additive);
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
