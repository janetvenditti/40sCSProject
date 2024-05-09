using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transistionAnim;
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
    public void NextScene()
    {
        StartCoroutine(LoadLevel());
    }
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
        //StartCoroutine(LoadLevel());

    }

    IEnumerator LoadLevel()
    {
        transistionAnim.SetTrigger("Scene Enter");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        yield return new WaitForSeconds(1);
        transistionAnim.SetTrigger("Scene Exit");
    }
}

