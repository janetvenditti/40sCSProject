using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creating a option to create multiple of the scriptable object
//in asset menu
[CreateAssetMenu(fileName = "ItemOne", menuName = "Items/ItemOne")]
public class ItemOne : ScriptableObject
{
    //holds a bool value
    public bool Item1;

}
