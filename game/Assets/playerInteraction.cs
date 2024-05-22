using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject bubbleText; // Reference to the bubble text GameObject

    private Animator bubbleTextAnimator;

    void Start()
    {
        // Get the Animator component attached to the bubble text GameObject
        bubbleTextAnimator = bubbleText.GetComponent<Animator>();
    }

    // OnTriggerEnter2D is called when another Collider2D enters the trigger collider attached to this GameObject (Exit 1)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the player tag
        if (other.CompareTag("Player"))
        {
            // Log to the console
            Debug.Log("Player has interacted with Exit 1.");

            // Trigger the "Pop" animation of the bubble text once
            bubbleTextAnimator.SetTrigger("Pop");
        }
    }
}