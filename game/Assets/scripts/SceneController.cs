using System.Collections;
using System.Collections.Generic;
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

        transistionAnim.SetInteger("state", value: (int)state);
    }
    
    public void LoadScene(string sceneName)
    {
        //StartCoroutine(LoadLevel(sceneName));
        StartCoroutine(LoadLevel(sceneName));
        
    }

    IEnumerator LoadLevel(string sceneName)
    {
        state = TransistionState.exit;
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);
        state= TransistionState.enter;
       
    }
  
}

