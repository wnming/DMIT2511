using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JayAbilityController : MonoBehaviour
{
    private float minScale = 0.4f;
    private float maxScale = 1.0f;

    bool isShrinked;

    float shrinkingElapsedTime = 0;
    float shrinkingDelay = 0.5f;

    private void Start()
    {
        isShrinked = false;
    }

    public void ApplySizing(float rate)
    {
        transform.localScale = new Vector3(rate, rate, rate);
    }

    public void ChangePlayerSize()
    {
        if (isShrinked)
        {
            ApplySizing(minScale);
        }
        else
        {
            ApplySizing(maxScale);
        }
    }

    void Update()
    {
        shrinkingElapsedTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.R) && shrinkingElapsedTime > shrinkingDelay)
        {
            shrinkingElapsedTime = 0;
            isShrinked = !isShrinked;
            ChangePlayerSize();
        }
    }
}
