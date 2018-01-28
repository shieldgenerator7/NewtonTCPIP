using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundPicPiecer : MonoBehaviour
{

    List<GameObject> pieces = new List<GameObject>();
	public Material backgroundMaterial;
	public Texture backgroundTexture;
    private static BackgroundPicPiecer instance;

    // Use this for initialization
    void Start()
    {
		backgroundMaterial.mainTexture = backgroundTexture;

        instance = this;
        foreach (Transform t in transform)
        {
            if (t.gameObject != gameObject)
            {
                pieces.Add(t.gameObject);
                t.gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Shows the given amount of pixels, if available
    /// otherwise it will do nothing
    /// </summary>
    /// <param name="amount"></param>
    public static void ShowPixels(int amount)
    {
        instance.showPixels(amount);
    }

    private void showPixels(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int index = Random.Range(0, pieces.Count);
            pieces[index].SetActive(true);
            pieces.RemoveAt(index);
        }
    }
}
