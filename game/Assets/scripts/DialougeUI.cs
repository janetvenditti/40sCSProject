using System.Collections;
using UnityEngine;
using TMPro; //used to control the keyboard effect and most of the actual text 
public class DialougeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialougeObject testDialouge;
    //method to draw text in 

    private TypeWritterEffect typewritterEffect;
    private void Start()
    {
        //get typwritter 
       typewritterEffect = GetComponent<TypewritterEffect>();
       //pass in the object, then go to the coroutine to run through typewriter effect
       ShowDialouge(testDialouge);

    }

    //this takes in the dialouge object who's content we wnat to show
    public void ShowDialouge(DialougeObject dialougeObject)
    {
        StartCorountine(StepThroughDialouge(dialougeObject));
    }

    //lets wait for each array entry to go through 
    private IEnumerator StepThroughDialouge(DialougeObject dialougeObject)
    {
        foreach (string dialouge in dialougeObject. Dialouge)
        {
            yield return typewritterEffect.Run(dialouge, textLabel);
        }
    }
}
