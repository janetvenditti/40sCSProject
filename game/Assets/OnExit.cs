using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnExit : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D player)
    {
        SceneManager.LoadScene(sceneName);
    }
}
