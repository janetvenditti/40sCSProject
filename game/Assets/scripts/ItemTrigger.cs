using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool IsPickedUp;
    Vector2 gone = new Vector2(0,100);

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                IsPickedUp = true;
                transform.Translate(gone);
            }

        }
    }

    public bool getIsPickedUp()
    {
        return IsPickedUp;
    }
}
