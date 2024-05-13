using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedDoor : MonoBehaviour
{
    public ItemTrigger itemTrigger;
    [SerializeField] private string next;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(itemTrigger.getIsPickedUp() == true)
                {
                    SceneManager.LoadScene(next);
                }
            }

        }
    }
}
