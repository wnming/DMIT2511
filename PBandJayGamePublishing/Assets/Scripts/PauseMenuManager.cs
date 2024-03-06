using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameSceneManager pauseUI;
    public GameObject optionsMenuUI;

    private void Start()
    {
        pauseUI.gameObject.SetActive(false);
        //pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        optionsMenuUI.SetActive(false);
    }
    void Pause()
    {
        pauseUI.gameObject.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        optionsMenuUI.SetActive(false);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        GameSceneManager.QuitGame();
    }
    public void OptionsMenu()
    {
        pauseUI.gameObject.SetActive(false);
        optionsMenuUI.SetActive(true);
    }
    public void LoadPauseMenu()
    {
        pauseUI.gameObject.SetActive(true);
        optionsMenuUI.SetActive(false);
    }
}