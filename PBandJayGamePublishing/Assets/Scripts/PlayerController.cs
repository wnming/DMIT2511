using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    int idle;
    int jump;
    int walk;
    int run;
    int work;
    int attack;
    int victory;

    public float horizontalInput;
    public float verticalInput;

    float moveSpeed;
    float runSpeed;
    float jumpSpeed;
    float rotationSpeed;
    public bool isJumping = false;

    Rigidbody rigibody;

    void Start()
    {
        moveSpeed = 30.0f;
        runSpeed = 60.0f;
        rotationSpeed = 80.0f;
        jumpSpeed = 15.0f;

        rigibody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        idle = Animator.StringToHash("Idle");
        jump = Animator.StringToHash("Jump");
        walk = Animator.StringToHash("Walk");
        run = Animator.StringToHash("Run");
        work = Animator.StringToHash("Work");
        attack = Animator.StringToHash("Attack");
        victory = Animator.StringToHash("Victory");
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput == 0 && verticalInput == 0 && rigibody.velocity.y == 0)
        {
            animator.SetBool(idle, true);
            animator.SetBool(jump, false);
            animator.SetBool(walk, false);
            animator.SetBool(run, false);
            animator.SetBool(work, false);
            animator.SetBool(attack, false);
            animator.SetBool(victory, false);
        }
        else
        {
            if (isJumping)
            {
                animator.SetBool(idle, false);
                animator.SetBool(jump, true);
                animator.SetBool(walk, false);
                animator.SetBool(run, false);
                animator.SetBool(work, false);
                animator.SetBool(attack, false);
                animator.SetBool(victory, false);
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    animator.SetBool(idle, false);
                    animator.SetBool(jump, false);
                    animator.SetBool(walk, false);
                    animator.SetBool(run, true);
                    animator.SetBool(work, false);
                    animator.SetBool(attack, false);
                    animator.SetBool(victory, false);
                }
                else
                {
                    Debug.Log("walk");
                    animator.SetBool(idle, false);
                    animator.SetBool(jump, false);
                    animator.SetBool(walk, true);
                    animator.SetBool(run, false);
                    animator.SetBool(work, false);
                    animator.SetBool(attack, false);
                    animator.SetBool(victory, false);
                }
            }
        }

        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            rigibody.velocity = new Vector3(0, jumpSpeed, 0);
            isJumping = true;
        }

        rigibody.AddRelativeForce(Vector3.forward * verticalInput * (Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed));

        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
}
