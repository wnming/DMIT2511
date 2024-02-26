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
        runSpeed = 45.0f;
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
        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpSpeed, 0);
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //if (horizontalInput == 0 && verticalInput == 0)
        //{
        //    animator.SetBool(idle, true);
        //    animator.SetBool(jump, false);
        //    animator.SetBool(Run, false);
        //    animator.SetBool(BadgerPawAttack, false);
        //    animator.SetBool(BalloonFishDive, false);
        //    animator.SetBool(BalloonFishFloat, false);
        //}
        //if (Input.GetKey(KeyCode.LeftAlt))
        //{
        //    anim.SetBool(Walk, false);
        //    anim.SetBool(Idle, true);
        //    anim.SetBool(Run, false);
        //    anim.SetBool(BadgerPawAttack, false);
        //    anim.SetBool(BalloonFishDive, false);
        //    anim.SetBool(BalloonFishFloat, false);
        //}

        rigibody.AddRelativeForce(Vector3.forward * verticalInput * (Input.GetKey(KeyCode.LeftAlt) ? runSpeed : moveSpeed));

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
