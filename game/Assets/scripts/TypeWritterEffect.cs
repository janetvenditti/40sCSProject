using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWritterEffect : MonoBehaviour
{
    //starts the routine (runs it)
    // string to type, then label to write it on
   public void Run(string textToType, TMP_Text textLabel)
   {
        StartCoroutine(routine: TypeText(textToType, textLabel));

   }


    //types the text onto the label
   private IEnumerator TypeText(string textToType, TMP_Text textLabel)
   {
        //time elapsed since writting starts 
        float t = 0;
        //used to understand how many chars are typed at once
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            //becomes 1 after 1 second etc. 
            t += Time.deltaTime;

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
