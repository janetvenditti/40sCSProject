using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer Sr;

    public InputAction playerMovementTopDown;
    public InputAction playerMovementLeftRight;
    public InputAction playerSprint;
    public InputAction playerJump;
    public InputAction playerInteract;
    public InputAction playerEmote;

    public InputActions inputAction;
  

    Vector2 movement = Vector2.zero;
    Vector2 movementOutside = Vector2.zero;

    [SerializeField] private float speed = 0f;
    [SerializeField] private float WalkSpeed = 7f;
    [SerializeField] private float RunSpeed = 14f;
    [SerializeField] private float JumpHeight = 7f;


    private enum MovementState { idle, walking }
    private MovementState state = MovementState.idle;

    // Start is called before the first frame update


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerMovementTopDown.Enable();
        playerMovementLeftRight.Enable();
    }

    private void OnDisable()
    {
        playerMovementTopDown.Disable();
        playerMovementLeftRight.Disable();
    }
    // Update is called once per frame
    private void Update()
    {
        PlayerControlUpdate();
        FixedPlayerUpdate();
        AnimationUpdate(GetState());
    }

    private void PlayerControlUpdate()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        movement = playerMovementTopDown.ReadValue<Vector2>();
        movementOutside = playerMovementLeftRight.ReadValue<Vector2>();
    }
    private void FixedPlayerUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 3)
        {
            rb.velocity = new Vector2(movementOutside.x * WalkSpeed, movementOutside.y * WalkSpeed);
        }
        else
        {
            rb.velocity = new Vector2(movement.x * WalkSpeed, movement.y * WalkSpeed);
        }
    }

    private MovementState GetState()
    {
        return state;
    }

    private void AnimationUpdate(MovementState state)
    {
        if (SceneManager.GetActiveScene().buildIndex <= 3)
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
        else
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
        anim.SetInteger("state", value: (int)state);
    }
}