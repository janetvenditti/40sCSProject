using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacttriggerpoint : MonoBehaviour
{
    [SerializeField] public bool goNextScene;
    [SerializeField] public string levelName;
    [SerializeField] public bool needInput;
    private bool isInCollider;
    //[SerializeField] public Collider2D collision;


    private bool isNextScene = true;
    [SerializeField] public SceneInfo sceneInfo;

    private PlayerMovement playerInput;
    //private bool interact = PlayerMovement.IsInteracted();
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            if (playerInput.IsInteracted() == true)
            {
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
}
