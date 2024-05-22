using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interacttriggerpoint : MonoBehaviour
{
    [SerializeField] private string next;
    public PlayerMovement move;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(move.IsInteracted() == true) 
            {
                SceneManager.LoadScene(next);
            }
        }
    }
}
