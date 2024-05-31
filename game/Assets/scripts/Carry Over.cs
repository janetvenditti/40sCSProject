using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CarryOver : MonoBehaviour
{
    public static GameObject instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(instance);
        }


    }

}
