using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial2LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scorePanel;

    public QuotaManager quotaManager;
    public DialougeHover dialougeHover;

    public DialogueManager dialogueManager;

    public Snap snapManager; 

    public GameObject start;

    public GameObject retry;

    public GameObject nextLvl;

    public bool isStart = false; 

    [SerializeField]
    bool isScoreOpen = false;
    void Start()
    {
        dialogueManager.endDialogueDelegate = ActivateChickenDrag;
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueManager.counter == 6 && snapManager.isSnapped == true)
        {
            dialogueManager.showButton();
        }

        if(isStart == true)
        {
            start.SetActive(false);
            StartCoroutine(CheckEggisNullDelay());

        }

        if(isScoreOpen == true)
        {
            dialogueManager.endDialogueDelegate = goNextLevel;
        }

        if(dialogueManager.counter == 10)
        {
            goNextLevel();
        }
        
    }

    void ActivateChickenDrag()
    {
        GameObject.FindWithTag("Chicken").GetComponent<DragChick>().isPaused = false;
        GameObject.Find("Task").GetComponent<DialogueTrigger>().enabled = true;
        dialogueManager.endDialogueDelegate = TaskComplete;
        
    }

    void TaskComplete()
    {
        GameObject.Find("ReadyText").GetComponent<DialogueTrigger>().enabled = true;
        start.SetActive(true);

    }

    void CheckScore()
    {
        StopCoroutine(CheckEggisNullDelay());
        scorePanel.SetActive(true);
        isScoreOpen = true;
        quotaManager.CompleteMandatory();
        int score = int.Parse(scorePanel.GetComponent<TextSetter>().newText.text);
        if(score >= 5){
            quotaManager.CompleteOpt();
            GameObject.Find("Congratz").GetComponent<DialogueTrigger>().enabled = true;
            isScoreOpen = true;
        }else{
            GameObject.Find("Condition1").GetComponent<DialogueTrigger>().enabled = true;
            isScoreOpen = true;
            goNextLevel();
        }
    }

    public void StartGame()
    {
        isStart = true;
    }

    IEnumerator CheckEggisNullDelay()
    {
        yield return new WaitForSeconds(5.0f);
        if(GameObject.Find("DialougeUI") == null && GameObject.FindWithTag("Egg") == null){
            GameObject.Find("TextBox").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("CheckScoreDialouge").GetComponent<DialogueTrigger>().enabled = true;
            dialogueManager.endDialogueDelegate = CheckScore;
        }

    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Tutorial2");
    }

    void goNextLevel()
    {
        retry.SetActive(true);
        nextLvl.SetActive(true);
    }




}
