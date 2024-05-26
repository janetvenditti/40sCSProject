using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialouge/DialougeObject")]
//inherit from scriptable object, dont like hard code in the text 
public class DialougeObject : ScriptableObject
{
    //pick the dialouge items possible to show a player
   [SerializeField] [TextArea] private string[] dialouge;

    //make a getter to return the private dialouge string array, dont override the unity text 
   public string[] Dialogue => dialouge;
}
