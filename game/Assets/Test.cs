using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Test : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 movement;
    [SerializeField] private float WalkSpeed = 7f;
    [SerializeField] private float RunSpeed = 14f;
    [SerializeField] private float JumpHeight = 7f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        PlayerControls Controls = new PlayerControls();
        Controls.Player.Enable();
        Controls.Player.Jump.performed += Jump;

        Controls.Player.TopDown.performed += TopDown;
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("TEST" + context.phase);
            rb.velocity = new Vector3(rb.velocity.x, 5f);
        }
    }

    public void TopDown(InputAction.CallbackContext context)
    {
        Debug.Log("TEST" + context.phase);
    }
}
