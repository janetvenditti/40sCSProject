using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
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

    //Vector2 movement = Vector2.zero;

    private TriggerPoint triggerPoint;


    [SerializeField] private float WalkSpeed = 7f;
    [SerializeField] private float RunSpeed = 14f;
    [SerializeField] private float JumpHeight = 7f;
    private float speed;

    private enum MovementState { idle, walking, running }
    private MovementState state = MovementState.idle;

    public MasterInput Controls;
 

    private MasterInput playerControls;
    private bool interacted;
  

    Vector2 inputVector;

   public bool isJumping;





    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

       
        interacted = false;

        speed = WalkSpeed;

        //if(rb.y)
        

        

    }
    private void OnEnable()
    {
      

        
        //Controls.Enable ();
        //playerControls.Enable();


    }

    private void OnDisable()
    {
        
        
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
      
        //getKeyPress();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 3)
        {
            TopDown();
            rb.gravityScale = 0;
        }
        else
        {
            RightLeft();
            rb.gravityScale = 2;
        }

        

            

    }

    public void Jump(InputAction.CallbackContext context)
    {
        
        Debug.Log(context.phase);
      
       
       if (SceneManager.GetActiveScene().buildIndex < 3)
        {
            if (context.performed && !isJumping)
            {
                isJumping = true;
                rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
                
         
            }

        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    { 
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }


    public void TopDown()
    {
        Vector2 movement = new Vector2(inputVector.x * speed * Time.deltaTime, inputVector.y * speed * Time.deltaTime);
        transform.Translate(movement);
    }

    public void RightLeft()
    {

        Vector2 movement = new Vector2(inputVector.x * speed * Time.deltaTime, 0);
        transform.Translate(movement);

        
    }
    public void Interact(InputAction.CallbackContext context) 
    {
        Debug.Log(context);
        
          interacted = true;
          
        
        
   
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        {
            speed = RunSpeed;

        }
        if(context.canceled)
        {
            speed = WalkSpeed;
        }
    }

    public bool IsInteracted()
    {
        return interacted;
        
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
                
                if (speed == WalkSpeed)
                {
                    state = MovementState.walking;
                }
                else
                {
                    state = MovementState.running;
                }

            }
            if (inputVector.x < 0 || inputVector.y < 0)
            {
                Sr.flipX = true;
                if (speed == WalkSpeed)
                {
                    state = MovementState.walking;
                }
                else
                {
                    state = MovementState.running;
                }

            }
        }
        else
        {
            if (inputVector.x > 0)
            {
                Sr.flipX = false;

                if (speed == WalkSpeed)
                {
                    state = MovementState.walking;
                }
                else
                {
                    state = MovementState.running;
                }

            }
            if (inputVector.x < 0)
            {
                Sr.flipX = true;
                if (speed == WalkSpeed)
                {
                    state = MovementState.walking;
                }
                else
                {
                    state = MovementState.running;
                }


            }
        }
        anim.SetInteger("state", value: (int)state);
    }  
}