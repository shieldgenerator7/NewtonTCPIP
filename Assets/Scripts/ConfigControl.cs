using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigControl : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			string myJob = this.name;
			if (SceneManager.GetSceneByName ("ControlSettings").isLoaded) {
				SceneManager.UnloadSceneAsync ("ControlSettings");
			} else if (SceneManager.GetSceneByName ("Level7").isLoaded) {
				SceneManager.UnloadSceneAsync ("Level7");
			}

			if (myJob == "MainMenu")
				LoadMenu ();

		}
	}
	void LoadMenu(){
		SceneManager.LoadScene ("MainMenu",LoadSceneMode.Additive);
	}
}
