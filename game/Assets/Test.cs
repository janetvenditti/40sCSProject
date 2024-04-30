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

    private Vector2 movement;
    [SerializeField] private float WalkSpeed = 7f;
    [SerializeField] private float RunSpeed = 14f;
    [SerializeField] private float JumpHeight = 7f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(movement);
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
