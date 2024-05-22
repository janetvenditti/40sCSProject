using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D col;
    public  ContactFilter2D contactFilter;
    public float groundDist = 0.05f;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    public bool IsGround { get { return grounded; } private set { grounded = value; } }
    public bool grounded = true;    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }


    private void FixedUpdate()
    {
        IsGround = col.Cast(Vector2.down, contactFilter, groundHits, groundDist) > 0;
    }
}
