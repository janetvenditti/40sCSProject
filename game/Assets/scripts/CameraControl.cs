using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //transform of player object
    [SerializeField] private Transform player;
    // Update is called once per frame
    private void Update()
    {
        //Changes cameras x and y to players x and y each frame
        //while keeping z constant
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
