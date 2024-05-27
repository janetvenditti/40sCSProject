using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWritterEffect : MonoBehaviour
{
     [SerializeField] private float typewriterSpeed = 50f;

    //starts the routine (runs it)
    // string to type, then label to write it on
   public Coroutine Run(string textToType, TMP_Text textLabel)
   {
        return StartCoroutine(routine: TypeText(textToType, textLabel));
   }


    //types the text onto the label
   private IEnumerator TypeText(string textToType, TMP_Text textLabel)
   {
          //the box begins without any text!
          textLabel.text = string.Empty;
        
        //time elapsed since writting starts 
        float t = 0;
        //used to understand how many chars are typed at once
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            //becomes 1 after 1 second etc. increments
            //now the speed multiplier can change the time of text appearence 
            t += Time.deltaTime * typewriterSpeed;

            //stored the rounded value of the timer 
            charIndex = Mathf.FloorToInt(t);

            //only typing for the message duration needed 
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            //text left to type 
            textLabel.text = textToType.Substring(0, charIndex);

            //wait one frame
            yield return null; 
        }

        textLabel.text = textToType;
   }

}
