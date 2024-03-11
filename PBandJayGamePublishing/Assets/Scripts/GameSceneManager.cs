using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameObject pauseMenu;
    private static bool isGamePaused = false;

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public static void LoadMysticMaze()
    {
        SceneManager.LoadScene(1);
    }
    public static void LoadGameHUB()
    {
        SceneManager.LoadScene(2);
    }
    public static void LoadMainLevel()
    {
        SceneManager.LoadScene(3);
    }
    public static void LoadWheresMyMom()
    {
        SceneManager.LoadScene(4);
    }
    public static void LoadSaveThePenguins()
    {
        SceneManager.LoadScene(5);
    }
    public static void LoadFeedThePolarBear()
    {
        SceneManager.LoadScene(6);
    }
    
    public static void LoadPauseMenu()
    {
        if (pauseMenu != null)
        {
            isGamePaused = !isGamePaused;
            pauseMenu.SetActive(isGamePaused);
            Time.timeScale = isGamePaused ? 0 : 1;
        }
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
}