using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitInput : MonoBehaviour
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
            Debug.Log(playerInput.getKeyPress());
            isInCollider = true;
            if (needInput == true)
            {
                if (playerInput.getKeyPress() == true)
                {
                    Debug.Log(playerInput.getKeyPress());
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
            else
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
        isInCollider = false;


    }

    public bool IsInside()
    {
        return isInCollider;
    }







}

