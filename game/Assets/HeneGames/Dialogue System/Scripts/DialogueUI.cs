using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

     //note that the dialougeWindow reveals the main text box, the interactionUI reveals another box for text, not needed yet!
    //the contents of the text box can be edited on unity in the dialouge asset dropdown from the dialouge UI
   //the extra box will be revealed to be edited under interaction UI, with another text editing area
   
namespace HeneGames.DialogueSystem
{
    public class DialogueUI : MonoBehaviour
    {
        #region Singleton
        //make an instance of the dialouge box object 
        public static DialogueUI instance { get; private set; }

        #endregion
        //set up for animation and spaces filled in the text box 
        private DialogueManager currentDialogueManager;
        private bool typing;
        private string currentMessage;
        private float startDialogueDelayTimer;

        [Header("References")]
        [SerializeField] private Image portrait;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private GameObject dialogueWindow;
        [SerializeField] private GameObject interactionUI;

        [Header("Settings")]
        [SerializeField] private bool animateText = true;

        [Range(0.1f, 1f)]
        [SerializeField] private float textAnimationSpeed = 0.5f;

        [Header("Next sentence input")]
        public KeyCode actionInput = KeyCode.Space;

        private void Start()
        {
            //reveal the main charecter dialogue UI at start (on play) by setting this to true
            dialogueWindow.SetActive(true);
            //set this to true if you need more text space, not needed now so it's set to false
            interactionUI.SetActive(false);
        }

        private void Update()
        {
            //delay timer
            if (startDialogueDelayTimer > 0f)
            {
                startDialogueDelayTimer -= Time.deltaTime;
            }

            //next dialogue input, if there is any 
            if (Input.GetKeyDown(actionInput))
            {
                if (startDialogueDelayTimer <= 0f)
                {
                    if (!typing)
                    {
                        NextSentence();
                    }
                    else
                    {
                        StopAllCoroutines();
                        typing = false;
                        messageText.text = currentMessage;
                    }
                }
            }
        }

        public void NextSentence()
        {
            //continue only if we have dialogue
            if (currentDialogueManager == null)
                return;

            //tell the current dialogue manager to display the next sentence. This function also gives information if we are at the last sentence
            currentDialogueManager.NextSentence(out bool lastSentence);

            //if last sentence remove current dialogue manager
            if (lastSentence)
            {
                currentDialogueManager = null;
            }
        }

        public void StartDialogue(DialogueManager _dialogueManager)
        {
            //delay timer
            startDialogueDelayTimer = 0.1f;

            //store dialogue manager
            currentDialogueManager = _dialogueManager;

            //start displaying dialogue
            currentDialogueManager.StartDialogue();
        }

        public void ShowSentence(DialogueCharacter _dialogueCharacter, string _message)
        {
            StopAllCoroutines();

            dialogueWindow.SetActive(true);

            portrait.sprite = _dialogueCharacter.characterPhoto;
            nameText.text = _dialogueCharacter.characterName;
            currentMessage = _message;

            if (animateText)
            {
                StartCoroutine(WriteTextToTextmesh(_message, messageText));
            }
            else
            {
                messageText.text = _message;
            }
        }

        public void ClearText()
        {
            dialogueWindow.SetActive(false);
        }

        public void ShowInteractionUI(bool _value)
        {
            interactionUI.SetActive(_value);
        }

        public bool IsProcessingDialogue()
        {
            if (currentDialogueManager != null)
            {
                return true;
            }

            return false;
        }

        IEnumerator WriteTextToTextmesh(string _text, TextMeshProUGUI _textMeshObject)
        {
            typing = true;

            _textMeshObject.text = "";
            char[] _letters = _text.ToCharArray();

            float _speed = 1f - textAnimationSpeed;

            foreach (char _letter in _letters)
            {
                _textMeshObject.text += _letter;

                if (_textMeshObject.text.Length == _letters.Length)
                {
                    typing = false;
                }

                yield return new WaitForSeconds(0.1f * _speed);
            }
        }
    }
}