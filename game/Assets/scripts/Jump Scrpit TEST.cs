using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    Vector2 movement = Vector2.zero;
    [SerializeField] private float WalkSpeed = 7f;
    [SerializeField] private float RunSpeed = 14f;
    [SerializeField] private float JumpHeight = 7f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        MasterInput playerControls = new MasterInput();
        playerControls.Player.Enable();
        playerControls.Player.Jump.performed += Jump;
        

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
}