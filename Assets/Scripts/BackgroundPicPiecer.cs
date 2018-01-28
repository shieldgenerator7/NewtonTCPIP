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

	public GameObject camman;
	public Vector3 background = new Vector3(0,0,60);

    private int pixelsLeft = 0;//how many pixels are left to uncover

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
        pixelsLeft = pieces.Count;

		camman = GameObject.Find ("Main Camera");	
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
            if (pixelsLeft > 0)
            {
                int index = Random.Range(0, pieces.Count);
                GameObject go = pieces[index];
                while (go == null)
                {
                    index++;
                    if (index >= pieces.Count)
                    {
                        index = 0;
                    }
                }
                go.SetActive(true);
                pieces.RemoveAt(index);
                pixelsLeft--;
            }
        }
    }

	void Update(){
		transform.position = camman.transform.position +background;
	}
}
