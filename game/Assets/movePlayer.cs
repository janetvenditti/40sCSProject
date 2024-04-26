using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;
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

    public MasterInput Controls;
    private InputAction move;
    private InputAction moveSide;
    private InputAction jump;
    private InputAction E;

    private MasterInput playerControls;





    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Controls = new MasterInput();

        MasterInput playerControls = new MasterInput();
        playerControls.Player.Enable();
        playerControls.Player.Jump.performed += Jump;

        //Controls.Player.Jump.performed += Jump;

    }
    private void OnEnable()
    {
        moveSide = Controls.Player.RightLeft;
        move = Controls.Player.TopDown;
        //jump = Controls.Player.Jump;
        E = Controls.Player.Interact;

        move.Enable();
        moveSide.Enable();
        //jump.Enable();
        E.Enable();
        Controls.Enable ();
        playerControls.Enable();


    }

    private void OnDisable()
    {
        
        move.Disable();
        moveSide.Disable();
        //jump.Disable();
        E.Disable();
        Controls.Disable();
        playerControls.Disable();
    }
    void Start()
    {

        anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex >= 3)
        {
            movement = move.ReadValue<Vector2>();

        }
        else
        {
            
            movement = moveSide.ReadValue<Vector2>();
        }

        AnimationUpdate(state);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 3)
        {
            rb.velocity = new Vector2(movement.x * WalkSpeed, movement.y * WalkSpeed);

        }
        else
        {
            //Controls.Player.Jump.performed += Jump;
            rb.velocity = new Vector2(movement.x * WalkSpeed, movement.y);
        }

        E.performed += Interact;
        
    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            Debug.Log("TEST" + context.phase);
            rb.velocity = new Vector3(rb.velocity.x, 5f);
        }
    }

    public void Interact(InputAction.CallbackContext context) 
    {
        Debug.Log(context);
        if (context.performed) 
        {
            Debug.Log("TEST" + context.phase);
            
        }
    }

    private MovementState GetState()
    {
        return state;
    }

    private void AnimationUpdate(MovementState state)
    {
        if (SceneManager.GetActiveScene().buildIndex >= 3)
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