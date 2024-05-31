using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interacttriggerpoint : MonoBehaviour
{
    [SerializeField] private string next;
    public IsPressed pressed;
    private void OnTriggerStay2D(Collider2D collision)
    {
        //compares tag of 2D collider to colider with player tag
        if(collision.CompareTag("Player"))
        {
            //checks if interact button is pressed
            if(pressed.pressed == true) 
            {
                //loads next scene
                SceneController.instance.LoadScene(next);
            }
        }
    }
}
