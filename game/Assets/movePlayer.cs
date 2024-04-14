using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
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



    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisbale()
    {

    }
    // Update is called once per frame


    private void PlayerControlUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }

    private void FixedPlayerUpdate()
    {
        
            rb.MovePosition(rb.position + movement * WalkSpeed * Time.fixedDeltaTime);
       
    }

   

    private MovementState GetState()
    {
        return state;
    }

    private void AnimationUpdate(MovementState state)
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

        anim.SetInteger("state", value: (int)state);
    }
}