using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField] public string levelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //compares 2D collider to object with player tag
        if (collision.CompareTag("Player"))
        {
           //loads next scene
           SceneController.instance.LoadScene(levelName);
          
        }
        
    }



   





}
