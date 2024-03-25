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
    public float jumpSpeed;
    float rotationSpeed;
    public bool isJumping;
    public bool jumped;

    public bool isRun = false;

    public Rigidbody rigibody;

    void Start()
    {
        moveSpeed = 30.0f;
        runSpeed = 60.0f;
        rotationSpeed = 80.0f;
        jumpSpeed = 500.0f;        
        isJumping = false;
        jumped = false;

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
        if (horizontalInput == 0 && verticalInput == 0 && !isJumping)
        {
            Debug.Log("horizontalInput == 0 && verticalInput == 0 && !isJumping");
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
                if (!jumped)
                {
                    Debug.Log("(!jumped)");
                    jumped = true;
                    animator.SetBool(idle, false);
                    animator.SetBool(jump, true);
                    animator.SetBool(walk, false);
                    animator.SetBool(run, false);
                    animator.SetBool(work, false);
                    animator.SetBool(attack, false);
                    animator.SetBool(victory, false);
                }
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
                    Debug.Log("else walk");
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
        rigibody.AddRelativeForce(Vector3.forward * verticalInput * (isRun ? runSpeed : moveSpeed));
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        isJumping = true;
        rigibody.velocity = new Vector3(0, 15.0f, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") && rigibody.velocity.y <= 0)
        {
            isJumping = false;
            jumped = false;
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.GetComponent<Terrain>() is not null)
    //    {
    //        Debug.Log("ggg");
    //        isJumping = false;
    //    }
    //}
}
