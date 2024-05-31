using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//creating a option to create multiple of the scriptable object
//in asset menu
[CreateAssetMenu(fileName = "Pressed", menuName = "ButtonData/Pressed")]
public class IsPressed : ScriptableObject
{
   
    public bool pressed;
}
