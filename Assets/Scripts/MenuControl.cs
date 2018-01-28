using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			string myJob = this.name;
			if (SceneManager.GetSceneByName("MainMenu").isLoaded)
			{
				SceneManager.UnloadSceneAsync("MainMenu");
			}

			if (myJob == "PlayLevel")
				PlayLevel ();
			else if (myJob == "RandomLevel")
				RandomLevel ();
			else if (myJob == "CreditsScreen")
				CreditScreen ();
			else  if (myJob == "ControlSettings")
				ControlSettings ();
			else  if (myJob == "Exit")
				Application.Quit();
		}
	}

	void PlayLevel(){
			SceneManager.LoadScene ("Level1",LoadSceneMode.Additive);
	}

	void RandomLevel(){
			SceneManager.LoadScene ("RandomLevel",LoadSceneMode.Additive);
	}

	void CreditScreen(){
			SceneManager.LoadScene ("CreditsScreen",LoadSceneMode.Additive);
	}

	void ControlSettings(){
			SceneManager.LoadScene ("ControlSettings",LoadSceneMode.Additive);
	}


}
