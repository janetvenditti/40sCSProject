using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerMovement : MonoBehaviour
{
    //player RigidBody, Animator and sprite
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer Sr;
   
    //float values for runs speed, walk speed and jump height
    [SerializeField] private float WalkSpeed = 7f;
    [SerializeField] private float RunSpeed = 14f;
    [SerializeField] private float JumpHeight = 7f;
    //variable for speed
    private float speed;
    
    //states for animation
    private enum MovementState { idle, walking, running }
    //automatically sets animation to idle
    private MovementState state = MovementState.idle;

    //scriptable object checks if interact button is pressed
    [SerializeField] private IsPressed pressed;
    //vector2 variable for movement
    private Vector2 inputVector;
    //bool chekcs if player is currently jumping
    private bool isJumping;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
       
        //setting speed to normal walking
        speed = WalkSpeed;
    }

    private void Update()
    {
        //updating aninmation every frame
        AnimationUpdate(state);
    }

    private void FixedUpdate()
    {
        //checking scene build index to activate needed controlls
        if (SceneManager.GetActiveScene().buildIndex >= 3)
        {
            TopDown();
            rb.gravityScale = 0;
        }
        else
        {
            RightLeft();
            rb.gravityScale = 2;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        //checking build index for scene than needs jump
        if (SceneManager.GetActiveScene().buildIndex < 3)
        {
            //checking if button is pressed and player is not
            //currently jumping
            if (context.performed && !isJumping)
            {
                isJumping = true;
                rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    { 
        //checking if player collider is in contact with ground tag collider
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    public void SetVector(InputAction.CallbackContext context)
    {
        //setting vector2 variable to vector2 value recived per every interaction
        inputVector = context.ReadValue<Vector2>();
    }
    public void TopDown()
    {
        //using inputvector to change movement direction based on its value
        Vector2 movement = new Vector2(inputVector.x * speed * Time.deltaTime, inputVector.y * speed * Time.deltaTime);
        transform.Translate(movement);
    }

    public void RightLeft()
    {
        //using inputvector to change movement direction based on its value
        Vector2 movement = new Vector2(inputVector.x * speed * Time.deltaTime, 0);
        transform.Translate(movement);
    }
    public void Interact(InputAction.CallbackContext context) 
    {
        if (context.performed)
        {
            //setting pressed bool to true if button pressed
            pressed.pressed = true;
        }
        else
        {
            pressed.pressed = false;
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //setting speed to running speed when button held
            speed = RunSpeed;
        }
        if(context.canceled)
        {
            //setting speed to normal speed when button is let go
            speed = WalkSpeed;
        }
    }

    private void AnimationUpdate(MovementState state)
    {
        //checking if scene needs top down animation or left right
        if (SceneManager.GetActiveScene().buildIndex >= 3)
        {
            //checking if player is moving up or to right
            if (inputVector.x > 0 || inputVector.y > 0)
            {
                Sr.flipX = false;
                //checking if player is sprinting
                if (speed == WalkSpeed)
                {
                    state = MovementState.walking;
                }
                else
                {
                    state = MovementState.running;
                }

            }
            //checking if player is moving down of to left
            if (inputVector.x < 0 || inputVector.y < 0)
            {
                Sr.flipX = true;
                //checking if player is sprinting
                if (speed == WalkSpeed)
                {
                    state = MovementState.walking;
                }
                else
                {
                    state = MovementState.running;
                }
                

            }
        }
        else
        {
            //checking if player is moving to right
            if (inputVector.x > 0)
            {
                Sr.flipX = false;
                //checking if player is sprinting
                if (speed == WalkSpeed)
                {
                    state = MovementState.walking;
                }
                else
                {
                    state = MovementState.running;
                }

            }
            //checking if player is moving to left
            if (inputVector.x < 0)
            {
                Sr.flipX = true;
                //checking if player is sprinting
                if (speed == WalkSpeed)
                {
                    state = MovementState.walking;
                }
                else
                {
                    state = MovementState.running;
                }
            }
        }
        //changing state variable to interger value for animator state tree in unity
        anim.SetInteger("state", value: (int)state);
    }  
}