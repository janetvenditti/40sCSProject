using UnityEngine;
using TMPro; //used to control the keyboard effect and most of the actual text 
public class DialougeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;

    //method to draw text in 

    private void Start()
    {
       GetComponent<NewBehaviourScript>().Run("This is text\n Hey", textLabel);
       // textLabel.text = "Hello\nThis is the next line.";
    }
}
