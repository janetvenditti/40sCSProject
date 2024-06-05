using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedKey : MonoBehaviour
{
    public GameObject bubbleText; // Reference to the bubble text GameObject

    private Animator bubbleTextAnimator;
    [SerializeField] private ItemOne item;
    [SerializeField] private IsPressed pressed;

    void Start()
    {
        // Get the Animator component attached to the bubble text GameObject
        bubbleTextAnimator = bubbleText.GetComponent<Animator>();
    }

    // OnTriggerEnter2D is called when another Collider2D enters the trigger collider attached to this GameObject (Exit 1)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the player tag
        if (other.CompareTag("Player") && item.Item1 == false)
        {
            Debug.Log("E key pressed, triggering Pop animation.");

            // Trigger the "Pop" animation of the bubble text once
            bubbleTextAnimator.SetTrigger("Pop1");
        }
        // else if(other.CompareTag("Player") == false && item.Item1 == false)
        // {
        //     Debug.Log("Player has left");
        //     bubbleTextAnimator.Decline
        // }

    }
}