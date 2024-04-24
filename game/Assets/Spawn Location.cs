using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnLocation : MonoBehaviour
{

    [SerializeField] private Transform player;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
      if(TriggerPoint.isSceneChange() == true)
        {
            player.position = new Vector2(transform.position.x, transform.position.y);
        }
    }
}
