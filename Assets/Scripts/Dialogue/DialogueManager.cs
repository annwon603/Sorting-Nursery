using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<Text> sentences;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    [SerializeField]
    private GameObject nextButton;

    [Range(-1, 100)]
    public int counter = -1;

    public GameObject scorePanel;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<Text>();
        nextButton = GameObject.Find("NextButton");
    }

   public void StartDialouge (Dialogue dialogue)
   {
        nameText.text = dialogue.name;

        sentences.Clear();


        foreach (Text sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
   }

   public void DisplayNextSentence()
   {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        Text sentence = sentences.Dequeue();
        bool canButtonDisappear = sentence.needTaskComplete;
        dialogueText.text = sentence.dialouge;
        counter++;
        //Debug.Log("Dialogue #" + counter);
        if(canButtonDisappear == true)
        {
          hideButton();
        }
   }

   void EndDialogue()
   {
     //    scorePanel.SetActive(true);
     //    scorePanel.GetComponent<TextSetter>().Set();
        
        
        Debug.Log("Counter: " + counter);
   }

   public void hideButton()
   {
        nextButton.SetActive(false);
   }

   public void showButton()
   {
        nextButton.SetActive(true);
        DisplayNextSentence();
   }

   
}
