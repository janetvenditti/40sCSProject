using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField] public bool goNextScene; 
    [SerializeField] public string levelName;

    public bool isNextScene = true;
    [SerializeField] public SceneInfo sceneInfo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
