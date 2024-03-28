using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WheresMyMomLoad : MonoBehaviour
{
    GameObject jay;
    GameObject pennyB;
    Vector3 offSet = new Vector3(0, 0, 2.5f);

    [SerializeField] GameObject instructionPanel;
    [SerializeField] GameObject donePanel;

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
        Time.timeScale = 0;
        instructionPanel.SetActive(DataManager.wheresMyMomData.isThePuzzleDone ? false : true);
        donePanel.SetActive(DataManager.wheresMyMomData.isThePuzzleDone ? true : false);
        DataManager.currentScene = DataManager.SceneName.WheresMymom;
        jay = GameObject.FindGameObjectWithTag("Jay");
        jay.transform.localPosition = transform.position;
        jay.transform.localRotation = transform.rotation;
        pennyB = GameObject.FindGameObjectWithTag("PB");
        pennyB.transform.localPosition = transform.position + offSet;
        pennyB.transform.localRotation = transform.rotation;
    }

    public void CloseThePanel()
    {
        Time.timeScale = 1;
        if (DataManager.wheresMyMomData.isThePuzzleDone)
        {
            donePanel.SetActive(false);
        }
        else
        {
            instructionPanel.SetActive(false);
        }
    }
}
