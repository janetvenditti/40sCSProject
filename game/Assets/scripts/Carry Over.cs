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
            //stops object from being destroyed if it doesnt exist in next scene
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(instance);
        }


    }

}
