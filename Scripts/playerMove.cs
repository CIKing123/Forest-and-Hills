using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    public CharacterController control;

    public Transform trans;
   
    //Movement on Ground
    public float speed;
    Vector3 move;
    public Animator animator;

    //Gravity variables
    public float gravity = -10f;
    Vector3 velocity;
    public float jumpHeight = 18f;

   

    public Transform groundCheck,wallCheck;
    public LayerMask groundMask,wallMask;
    bool isGrounded;
    public float groundDist = 0.5f;


    bool isCrouching = false;
    bool OnWall;
    public float wallDist = 0.6f;

    public LayerMask edgeMask;
    bool OnEdge = false;
    public Transform edgeCheck;

    Quaternion wallRotate;
    public GameObject gameObj;
    float timeTaken;

   
    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist,groundMask);
        OnEdge = Physics.CheckSphere(edgeCheck.position,groundDist,edgeMask);

       

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            animator.SetBool("isGrounded", true);
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }

        float up = Input.GetAxisRaw("Vertical");
        
        if (Input.GetButtonDown("Fire1"))
        {
            speed = 21f;
            
        }
        else
        {
            speed = 12f;
        }


       
        float forward = Input.GetAxisRaw("Horizontal") * speed;
        move = trans.forward * forward + trans.up * up;
        control.Move(move * Time.deltaTime);

        
        animator.SetFloat("speed",Mathf.Abs(forward));

        velocity.y = velocity.y + gravity * Time.deltaTime;

        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetBool("isJumping", true);
            velocity.y = velocity.y + Mathf.Sqrt(gravity * -2f * jumpHeight);
            
        }
        else if(Input.GetButton("Jump") && !isGrounded)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isGrounded", false);
        }
     
        control.Move(velocity * Time.deltaTime);
        Crouch();
        if (isCrouching == true)
        {
            speed = 3f;
        }
        else
        {
            speed = 12f;
        }
        Flip(forward);
    }

    void Crouch()
    {
        if (Input.GetKey("c") && isGrounded)
        {
            isCrouching = true;
            animator.SetBool("isCrouching", true);
        }
        else
        {
            isCrouching=false;
            animator.SetBool("isCrouching", false);
        }

    }

    void Flip(float x)
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            gameObj.transform.localScale = new Vector3(1, 1, -1);
            animator.SetBool("IsTurning", true);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            gameObj.transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("IsTurning", true);
        }
        else
        {
            animator.SetBool("IsTurning", false);
        }
    }

    void WallSlide()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        OnWall = Physics.CheckBox(wallCheck.position, wallCheck.forward,wallRotate.normalized,wallMask);

        if (OnWall && !isGrounded)
        {
            animator.SetBool("OnWall", true);
            gravity = 6f;
        }
    }
}
