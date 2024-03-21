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

    PlayerController playerController;

    private void Start()
    {
        isGrown = false;
        playerController = GetComponent<PlayerController>();
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
        if (Input.GetKey(KeyCode.R) && growingElapsedTime > growingDelay)
        {
            growingElapsedTime = 0;
            isGrown = !isGrown;
            ChangePlayerSize();
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerController.isRun = true;
            }
            else
            {
                playerController.isRun = false;
            }
            playerController.horizontalInput = Input.GetAxis("Horizontal");
            playerController.verticalInput = Input.GetAxis("Vertical");
        }
        else
        {
            playerController.horizontalInput = 0;
            playerController.verticalInput = 0;
        }
        if (Input.GetKey(KeyCode.Space) && !playerController.isJumping)
        {
            playerController.isJumping = true;
        }
    }
}
