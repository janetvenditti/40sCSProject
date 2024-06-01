using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedDoor : MonoBehaviour
{
    //name of what scene should be changed to
    [SerializeField] private string next;
    //Scriptable object checking if player picked up item
    [SerializeField] private ItemOne item;
    //Scriptable Object checking if interact button is pressed
    [SerializeField] private IsPressed pressed;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //compares 2D collider tag to object with player tag
        if (collision.CompareTag("Player"))
        {
            //checks if interact button is pressed
            if (pressed.pressed == true)
            {
                //checks if item was "picked up"
                //is actually checking if bool is set true 
                if(item.Item1 == true)
                {
                    //scene change
                    SceneController.instance.LoadScene(next);
                }
            }

        }
    }
}
