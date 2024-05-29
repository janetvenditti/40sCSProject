using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transistionAnim;
    private enum TransistionState { exit, enter }
    private TransistionState state = TransistionState.enter;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }
    
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
        
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transistionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);
        transistionAnim.SetTrigger("Start");
       
    }
  
}

