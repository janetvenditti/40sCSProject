using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public int key;  // Static variable to persist across scenes

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            KeyManager.pickUpKey (key);
        }
    }
}
