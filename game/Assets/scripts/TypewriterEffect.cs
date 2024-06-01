using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    //starts the routine (runs it)
    // string to type, then label to write it on
   public Coroutine Run(string textToType, TMP_Text textLabel)
   {
        return StartCoroutine(routine: TypeText(textToType, textLabel));

   }


    //types the text onto the label
     private IEnumerator TypeText(string textToType, TMP_Text textLabel)
     {
          // Used to understand how many chars are typed at once
          int charIndex = 0;

          while (charIndex < textToType.Length)
          {
               // Increment charIndex based on time
               charIndex = Mathf.FloorToInt(Time.time);

               // Only typing for the message duration needed 
               charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

               // Text left to type 
               textLabel.text = textToType.Substring(0, charIndex);

               // Wait one frame
               yield return null; 
          }

          // Set the label to the complete text after typing finishes
          textLabel.text = textToType;
     }

}