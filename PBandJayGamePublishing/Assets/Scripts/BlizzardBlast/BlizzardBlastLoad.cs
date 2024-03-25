using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlizzardBlastLoad : MonoBehaviour
{
    GameObject jay;

    void Awake()
    {
        if (!SceneManager.GetSceneByName("Jay").isLoaded)
        {
            SceneManager.LoadScene("Jay", LoadSceneMode.Additive);
        }
    }

    void Start()
    {
        jay = GameObject.FindGameObjectWithTag("Jay");
        jay.transform.localPosition = transform.position;
    }
}
