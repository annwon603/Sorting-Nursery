using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button A, B;

    bool useMyOnClickHandler = true;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        A.onClick.AddListener(TaskOnClick);
        B.onClick.AddListener(TaskOnClick);
    }

    void TurnOffMyOnClickHandler()
    {
        useMyOnClickHandler = false;
    }

    void TaskOnClick()
    {
        if (!useMyOnClickHandler) return;

        FindObjectOfType<DialogueManager>().showButton();

        TurnOffMyOnClickHandler();
        //Output this to console when Button1 or Button3 is clicked
        
    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
    }

    void ButtonClicked(int buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);
    }

    
}

