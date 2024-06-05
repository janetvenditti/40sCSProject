using System.Collections; //lets us go through a list of collections, such as our writing objects!
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour //make a new class that inherits from monobehaviour so it can be used with game objects / components like the "test"
{
    [SerializeField] private float typewriterSpeed = 50f; //make a private variable that can be edited on unity 

    public Coroutine Run(string textToType, TMP_Text textLabel) //a coroutine method can pause to return new text lines 
    {
        return StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        textLabel.text = string.Empty;
        int charIndex = 0;    //track index of charecter being typed along 

        float delay = 1 / typewriterSpeed;   // delay with typing a character based on typewriterSpeed

        while (charIndex < textToType.Length)
        {
     
            textLabel.text += textToType[charIndex];    //do next character
            charIndex++;

            yield return new WaitForSeconds(delay);     // wait for the time of delay
        }
    }
}
