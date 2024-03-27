using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlizzardBlastLoad : MonoBehaviour
{
    GameObject jay;
    GameObject pennyB;
    Vector3 offSet = new Vector3(2.5f, 0 , 0);

    void Awake()
    {
        if (!SceneManager.GetSceneByName("Jay").isLoaded)
        {
            SceneManager.LoadScene("Jay", LoadSceneMode.Additive);
        }
        if (!SceneManager.GetSceneByName("PennyB").isLoaded)
        {
            SceneManager.LoadScene("PennyB", LoadSceneMode.Additive);
        }
    }

    void Start()
    {
        DataManager.isInMainArea = true;
        jay = GameObject.FindGameObjectWithTag("Jay");
        jay.transform.localPosition = transform.position + offSet;
        pennyB = GameObject.FindGameObjectWithTag("PB");
        pennyB.transform.localPosition = transform.position;
    }
}
