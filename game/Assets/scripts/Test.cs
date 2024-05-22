using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Test : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer Sr;

    Vector2 movement;


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
    private PlayerInput playerInput;
   

    

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //AnimationUpdate(state);
    }

    public void Jump(InputAction.CallbackContext context) 
    {
        Debug.Log(context.phase);

        if(context.started) 
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
        }
    }

    public void TopDown(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
        if (SceneManager.GetActiveScene().buildIndex >= 3)
        {
            movement = context.ReadValue<Vector2>();

        }
        
    }

    public void RightLeft(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());

        if (SceneManager.GetActiveScene().buildIndex < 3)
        {
            movement = context.ReadValue<Vector2>();
        }
    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 3)
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

   
}
