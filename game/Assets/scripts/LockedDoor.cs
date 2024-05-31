using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedDoor : MonoBehaviour
{
    public ItemTrigger itemTrigger;
    [SerializeField] private string next;
    public PlayerMovement move;
    public ItemOne item;
  
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (move.IsInteracted() == true)
            {
                if(item.Item1 == true)
                {
                    SceneController.instance.LoadScene(next);
                }
            }

        }
    }
}
