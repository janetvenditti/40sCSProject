using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer Sr;

    Vector2 movement;
    [SerializeField] private float RunSpeed = 7f;
 
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
 
        PlayerControlUpdate();
        FixedPlayerUpdate();
    }
 
    private void PlayerControlUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
    }

    private void FixedPlayerUpdate()
    {
        rb.MovePosition(rb.position + movement * RunSpeed * Time.fixedDeltaTime);
    }
}