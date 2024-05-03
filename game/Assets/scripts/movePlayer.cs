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

    private TriggerPoint triggerPoint;


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
    private bool isPressed;

    Vector2 inputVector;





    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Controls = new MasterInput();


        MasterInput playerControls = new MasterInput();
        playerControls.Player.Enable();

        isPressed = false;
        

        

    }
    private void OnEnable()
    {
        moveSide = Controls.Player.RightLeft;
        move = Controls.Player.TopDown;
        jump = Controls.Player.Jump;
        E = Controls.Player.Interact;

        move.Enable();
        moveSide.Enable();
        jump.Enable();
        E.Enable();
        //Controls.Enable ();
        //playerControls.Enable();


    }

    private void OnDisable()
    {
        
        move.Disable();
        moveSide.Disable();
        jump.Disable();
        E.Disable();
        //Controls.Disable();
        //playerControls.Disable();
    }
    void Start()
    {

        anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        
        AnimationUpdate(state);
        getKeyPress();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 3)
        {
            TopDown();
        }
        else
        {
            RightLeft();
        }

            //E.performed += Interact;
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        
        Debug.Log(context.phase);
        if(context.performed) { rb.velocity = new Vector2(rb.velocity.x, JumpHeight); }
       
    }
    public void TopDown()
    {
        Vector2 movement = new Vector2(inputVector.x * WalkSpeed * Time.deltaTime, inputVector.y * WalkSpeed);
        transform.Translate(movement);
    }

    public void RightLeft()
    {

        Vector2 movement = new Vector2(inputVector.x * WalkSpeed * Time.deltaTime, 0);
        transform.Translate(movement);

        
    }
    public void Interact(InputAction.CallbackContext context) 
    {
        Debug.Log(context);
        if(context.performed)
        {
          isPressed = true;
          Debug.Log(isPressed);
            //triggerPoint.inputRequired();
        }
        
   
    }

    public bool getKeyPress()
    {
        Debug.Log(isPressed);
        return isPressed;
        
    }
    public void SetVector(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();

    }
    private MovementState GetState()
    {
        return state;
    }

    private void AnimationUpdate(MovementState state)
    {
        if (SceneManager.GetActiveScene().buildIndex >= 3)
        {
            if (inputVector.x > 0 || inputVector.y > 0)
            {
                Sr.flipX = false;

                state = MovementState.walking;

            }
            if (inputVector.x < 0 || inputVector.y < 0)
            {
                Sr.flipX = true;


                state = MovementState.walking;

            }
        }
        else
        {
            if (inputVector.x > 0)
            {
                Sr.flipX = false;

                state = MovementState.walking;

            }
            if (inputVector.x < 0)
            {
                Sr.flipX = true;


                state = MovementState.walking;

            }
        }
        anim.SetInteger("state", value: (int)state);
    }  
}