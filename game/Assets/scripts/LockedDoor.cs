using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedDoor : MonoBehaviour
{
    public ItemTrigger itemTrigger;
    [SerializeField] private string next;
    public PlayerMovement move;
  
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (move.IsInteracted() == true)
            {
                if(itemTrigger.getIsPickedUp() == true)
                {
                    SceneController.instance.LoadScene(next);
                }
            }

        }
    }
}
