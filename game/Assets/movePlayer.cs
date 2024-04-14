using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer Sr;

    Vector2 movement = Vector2.zero;
   
    
    [SerializeField] private float WalkSpeed = 7f;
    [SerializeField] private float RunSpeed = 14f;
    [SerializeField] private float JumpHeight = 7f;
   



    private enum MovementState { idle, walking }
    private MovementState state = MovementState.idle;

    public InputAction TopDown;
    public InputAction LeftRight;
    public InputAction Sprint;
    public InputAction Interact;
    public InputAction Jump;




    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

      
    }
    private void OnEnable()
    {
        TopDown.Enable();
        LeftRight.Enable();
        Sprint.Enable();
        Interact.Enable();
        Jump.Enable();
    }

    private void OnDisable()
    {
        TopDown.Disable();  
        LeftRight.Disable();
        Sprint.Disable();
        Interact.Disable();
        Jump.Disable();
    }
    void Start()
    {

        anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex >= 4)
        {
            movement = TopDown.ReadValue<Vector2>();
            isGrounded = Jump.ReadValue<bool>();
        }
        else
        {
            movement = LeftRight.ReadValue<Vector2>();
        }

        AnimationUpdate(state);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 4)
        {
            rb.velocity = new Vector2(movement.x * WalkSpeed, movement.y * WalkSpeed);

        }
        else
        {
            rb.velocity = new Vector2(movement.x * WalkSpeed, movement.y);

        }
    }

    private MovementState GetState()
    {
        return state;
    }

    private void AnimationUpdate(MovementState state)
    {
        if (SceneManager.GetActiveScene().buildIndex >= 4)
        {
            if (movement.x > 0 || movement.y > 0)
            {
                Sr.flipX = false;

                state = MovementState.walking;

            }
            if (movement.x < 0 || movement.y < 0)
            {
                Sr.flipX = true;


                state = MovementState.walking;

            }
        }
        else
        {
            if (movement.x > 0)
            {
                Sr.flipX = false;

                state = MovementState.walking;

            }
            if (movement.x < 0)
            {
                Sr.flipX = true;


                state = MovementState.walking;

            }
        }
        anim.SetInteger("state", value: (int)state);
    }  
}