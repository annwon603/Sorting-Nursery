using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button buttonA;
    public Button buttonB;
    
    private bool isButtonAActive = true; // Track the state of button A

    private void Start()
    {
        // Ensure buttons are set up and add listeners
        if (buttonA != null && buttonB != null)
        {
            // Add listeners to buttons
            buttonA.onClick.AddListener(() => OnButtonClicked(buttonA));
            buttonB.onClick.AddListener(() => OnButtonClicked(buttonB));
        }
    }

    private void OnButtonClicked(Button clickedButton)
    {
        // Perform the button's action
        NextDialogue();

        // Unsubscribe the NextDialogue function from both buttons
        UnsubscribeAll();
    }

    private void NextDialogue()
    {
        // Call the dialogue manager's method
        FindObjectOfType<DialogueManager>().showButton();
    }

    private void UnsubscribeAll()
    {
        // Unsubscribe the NextDialogue method from both buttons
        if (buttonA != null)
        {
            buttonA.onClick.RemoveListener(() => OnButtonClicked(buttonA));
        }
        if (buttonB != null)
        {
            buttonB.onClick.RemoveListener(() => OnButtonClicked(buttonB));
        }
    }
}

