using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHubManager : MonoBehaviour
{
    [SerializeField] int gameHub;

    private void OnTriggerEnter(Collider other)
    {
        if (gameHub == 0)
        {
            if (other.CompareTag("Jay") || other.CompareTag("PB"))
            {
                GameSceneManager.LoadMainLevel();
            }
        }

        if (gameHub == 1)
        {
            if (other.CompareTag("Jay") || other.CompareTag("PB"))
            {
                GameSceneManager.LoadMysticMaze();
            }
        }
    }
}