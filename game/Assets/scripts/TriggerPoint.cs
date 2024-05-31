using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField] public bool goNextScene; 
    [SerializeField] public string levelName;
    [SerializeField] public bool needInput;

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
