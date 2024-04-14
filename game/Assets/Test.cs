using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Test : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private PlayerControls playerControls;
    private InputAction action;

    Vector2 movement = Vector2.zero;
    [SerializeField] private float WalkSpeed = 7f;
    [SerializeField] private float RunSpeed = 14f;
    [SerializeField] private float JumpHeight = 7f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        PlayerControls playerControls = new PlayerControls();
        //playerControls.Player.Enable();
        playerControls.Player.Jump.performed += Jump;
        playerControls.Player.TopDown.performed += TopDown;

    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
            rb.velocity = new Vector3(rb.velocity.x, 5f);
        }
    }

    private void FixedUpdate()
    {
        movement = action.ReadValue<Vector2>();
        //rb.velocity = (new Vector2(inputVector.x, inputVector.y) * WalkSpeed);
    }

    public void TopDown(InputAction.CallbackContext context)
    {
       
        //Vector2 inputVector = context.ReadValue<Vector2>();
        rb.velocity = (new Vector2(movement.x, movement.y) * WalkSpeed);
    }
}
