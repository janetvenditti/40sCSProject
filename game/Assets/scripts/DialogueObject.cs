using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")] //inherit from scriptable object, dont like hard code in the text 
public class DialogueObject : ScriptableObject
{
    //pick the dialogue items possible to show a player
   [SerializeField] [TextArea] private string[] dialogue;

    //make a getter to return the private dialogue string array, dont override the unity text, get the private dialogue string array instead 
   public string[] Dialogue => dialogue;
}
