using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class JumpScrpitTEST : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private MasterInput playerControls;
    private InputAction action;
    private InputAction move;
    private InputAction moveSide;
    private InputAction jump;
    private InputAction E;

    private Vector2 movement;
    [SerializeField] private float WalkSpeed = 7f;
    [SerializeField] private float RunSpeed = 14f;
    [SerializeField] private float JumpHeight = 7f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        MasterInput playerContols = new MasterInput();
        //playerContols.Enable();

        //playerContols.Player.Jump.performed += Jump;
        //playerContols.Player.TopDown.performed += Move;
    }

    private void FixedUpdate()
    {
        //-playerControls.Player.TopDown.ReadValue<Vector2>();
        //Debug.Log(context);
        rb.MovePosition(movement);
        
    }
   
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            rb.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        rb.AddForce(new Vector2(movement.x, movement.y) * JumpHeight, ForceMode2D.Force);
    }
}