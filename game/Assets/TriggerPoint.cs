using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField] bool goNextScene;
    [SerializeField] string SceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (goNextScene)
            {
                SceneController.instance.NextScene();
            }
            else
            {
                SceneController.instance.LoadScene(SceneName);
            }
        }
    }
}
