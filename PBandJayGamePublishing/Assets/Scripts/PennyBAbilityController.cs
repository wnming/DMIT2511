using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PennyBAbilityController : MonoBehaviour
{
    private float minScale = 1.0f;
    private float maxScale = 1.6f;

    bool isGrown;

    float growingElapsedTime = 0;
    float growingDelay = 0.5f;

    private void Start()
    {
        isGrown = false;
    }

    public void ApplySizing(float rate)
    {
        transform.localScale = new Vector3(rate, rate, rate);
    }

    public void ChangePlayerSize()
    {
        if (isGrown)
        {
            ApplySizing(maxScale);
        }
        else
        {
            ApplySizing(minScale);
        }
    }

    void Update()
    {
        growingElapsedTime += Time.deltaTime;
        //might need to change to the different key later since Jay is already used R
        if (Input.GetKey(KeyCode.R) && growingElapsedTime > growingDelay)
        {
            growingElapsedTime = 0;
            isGrown = !isGrown;
            ChangePlayerSize();
        }
    }
}
