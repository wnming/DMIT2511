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

    PlayerController playerController;

    private void Start()
    {
        isShrinked = false;
        playerController = GetComponent<PlayerController>();
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
        if (Input.GetKey(KeyCode.L) && shrinkingElapsedTime > shrinkingDelay)
        {
            shrinkingElapsedTime = 0;
            isShrinked = !isShrinked;
            ChangePlayerSize();
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.RightShift))
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
        if (Input.GetKey(KeyCode.Return) && !playerController.isJumping)
        {
            playerController.isJumping = true;
            playerController.rigibody.AddForce(Vector3.up * playerController.jumpSpeed, ForceMode.Impulse);
            //playerController.Jump();
        }
    }
}
