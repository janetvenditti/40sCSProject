using System.Collections; //for coroutine => stepthroughdialogue
using UnityEngine;
using TMPro; //used to control the keyboard effect and most of the actual text 
public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;
    //method to draw text in 

    private TypewriterEffect typewriterEffect;
    private void Start()
    {
        //get typwritter 
       typewriterEffect = GetComponent<TypewriterEffect>();
       //pass in the object, then go to the coroutine to run through typewriter effect
       ShowDialogue(testDialogue);

    }

    //this takes in the dialogue object who's content we want to show
    public void ShowDialogue(DialogueObject dialogueObject)
    {
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    //lets wait for each array entry to go through 
    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach (string dialogue in dialogueObject. Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);
        }
    }
}