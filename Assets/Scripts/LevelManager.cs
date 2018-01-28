using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool debug = false;
    public int debugStartLevelNumber = 1;

    private Scene currentLevel;
    private int currentLevelNumber = 1;

    private static LevelManager instance;

	public int RandomLevelStageNumber;

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

        if (!debug)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        }
        else
        {
            if (SceneManager.GetSceneByName("Level" + debugStartLevelNumber).isLoaded)
            {
                SceneManager.UnloadSceneAsync("Level" + debugStartLevelNumber);
            }
            LoadLevel(debugStartLevelNumber);
        }

        RandomLevelStageNumber = 10;
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
			}else if (SceneManager.GetSceneByName("RandomLevel").isLoaded)
				{
				SceneManager.UnloadSceneAsync("RandomLevel");
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
