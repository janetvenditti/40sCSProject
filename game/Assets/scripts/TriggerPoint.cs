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
   private bool isInCollider;
    //[SerializeField] public Collider2D collision;


    private bool isNextScene = true;
    [SerializeField] public SceneInfo sceneInfo;

    private PlayerMovement playerInput;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            isInCollider = true;
            if (!isNextScene)
            {
                SceneController.instance.NextScene();
            }
            else
            {
                SceneController.instance.LoadScene(levelName);
            }

        }
        
    }



   





}
