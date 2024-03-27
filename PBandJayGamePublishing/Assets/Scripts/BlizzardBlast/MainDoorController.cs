using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorController : MonoBehaviour
{
    GameObject jay;
    GameObject pennyB;
    Vector3 offSet = new Vector3(0, 0, -2.5f);

    [SerializeField] GameObject toThePuzzles;
    [SerializeField] GameObject toTheMainArea;

    void Start()
    {
        jay = GameObject.FindGameObjectWithTag("Jay");
        pennyB = GameObject.FindGameObjectWithTag("PB");
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PB" || collision.gameObject.tag == "Jay")
        {
            jay.transform.localPosition = DataManager.isInMainArea ? toThePuzzles.transform.position + offSet : toTheMainArea.transform.position - offSet;
            jay.transform.localRotation = DataManager.isInMainArea ? toThePuzzles.transform.rotation : toTheMainArea.transform.rotation;
            pennyB.transform.localPosition = DataManager.isInMainArea ? toThePuzzles.transform.position : toTheMainArea.transform.position;
            pennyB.transform.localRotation = DataManager.isInMainArea ? toThePuzzles.transform.rotation : toTheMainArea.transform.rotation;
            DataManager.isInMainArea = !DataManager.isInMainArea;
        }
    }
}
