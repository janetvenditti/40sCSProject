using System.Collections; //for coroutine => stepthroughdialogue
using UnityEngine;
using TMPro; //used to control the keyboard effect and most of the actual text 
public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;
    //method to draw text in 

    private TypeWritterEffect typewritterEffect;
    private void Start()
    {
        //get typwritter 
       typewritterEffect = GetComponent<TypewritterEffect>();
       //pass in the object, then go to the coroutine to run through typewriter effect
       ShowDialogue(testDialogue);

    }

    //this takes in the dialogue object who's content we wnat to show
    public void ShowDialogue(DialogueObject dialogueObject)
    {
        StartCorountine(StepThroughDialogue(dialogueObject));
    }

    //lets wait for each array entry to go through 
    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach (string dialogue in dialogueObject. Dialogue)
        {
            yield return typewritterEffect.Run(dialogue, textLabel);
        }
    }
}
