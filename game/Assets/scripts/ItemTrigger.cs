using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public GameObject item;
    public ItemOne one;
    public IsPressed pressed;

    private void Awake()
    {
        //item is visable 
        item.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //compares 2D collider tag to object with player tag
        if (collision.CompareTag("Player"))
        {
            //checks if interact button is pressed
            if (pressed.pressed == true)
            {
                //sets scriptable object to true6
                one.Item1 = true;
                //sets object to no longer be visable
                item.SetActive(false);
            }

        }
    }

   
}
