using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractTriggerPoint : MonoBehaviour
{
    //name of what scene should be changed to
    [SerializeField] private string next;
    //Scriptable object checking if interact button is pressed
    [SerializeField] private IsPressed pressed;
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
