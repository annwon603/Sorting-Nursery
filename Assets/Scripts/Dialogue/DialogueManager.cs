using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.SearchService;

public class DialogueManager : MonoBehaviour
{
    private Queue<Text> sentences;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    [SerializeField]
    public GameObject nextButton;

    public GameObject retryButton;

    public GameObject nextLevelButton;

    [Range(-1, 100)]
    public int counter = -1;

    public GameObject scorePanel;
    public delegate void EndDialogueDelegate();

    public EndDialogueDelegate endDialogueDelegate;

    public GameObject TextBox;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<Text>();
        if(gameObject.scene.name != "IntroCutScene")
        {
           nextButton = GameObject.Find("NextButton");
        }
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
          endDialogueDelegate();
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
