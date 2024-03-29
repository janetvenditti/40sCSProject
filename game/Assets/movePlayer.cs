using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer Sr;
 
    private float dirX = 0f;
    [SerializeField] private float RunSpeed = 7f;
    [SerializeField] private float JumpHeight = 9f;
 
    private enum MovementState { idle, running, jumping, falling }
 
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
    }
 
    // Update is called once per frame
    void Update()
    {
 
        PlayerControl();
    }
 
    private void PlayerControl()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * RunSpeed, rb.velocity.y);
 
 
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpHeight);
        }
    }
}