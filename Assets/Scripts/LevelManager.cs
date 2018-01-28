using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private Scene currentLevel;
    private int currentLevelNumber = 1;

    private static LevelManager instance;

    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new UnityException("Duplicate LevelManagers!");
        }

		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Additive);
        //LoadLevel(currentLevelNumber);
    }

    public static void LoadNextLevel()
    {
        instance.loadLevel(instance.currentLevelNumber + 1);
    }

    public static void LoadLevel(int levelNumber, bool reload = true)
    {
        instance.loadLevel(levelNumber, reload);
    }

    private void loadLevel(int levelNumber, bool reload = true)
    {
        if (levelNumber != currentLevelNumber || reload)
        {
            if (SceneManager.GetSceneByName("Level" + currentLevelNumber).isLoaded)
            {
                SceneManager.UnloadSceneAsync("Level" + currentLevelNumber);
            }
            SceneManager.LoadScene("Level" + levelNumber, LoadSceneMode.Additive);
            currentLevelNumber = levelNumber;
            currentLevel = SceneManager.GetSceneByName("Level" + currentLevelNumber);
        }
    }

	void Update(){
		if(Input.GetKeyDown(KeyCode.P)){LoadNextLevel ();}
	}
}
