using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField] bool goNextScene;
    [SerializeField] string SceneName;

    public bool isNextScene = true;
    [SerializeField] public SceneInfo sceneInfo;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            sceneInfo.isNextScene = isNextScene;
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
