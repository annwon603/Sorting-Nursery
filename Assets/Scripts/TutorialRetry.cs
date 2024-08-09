using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TutorialRetry : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI textMeshProUGUI;
    public GameObject scorePanel;

    public GameObject QuotaPanel;

    public GameObject Dialouge;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If there are no eggs 
        if(GameObject.FindWithTag("Egg") == null && Time.deltaTime > 2.0)
        {
            Dialouge.SetActive(true);
            GameObject.Find("Task").GetComponent<DialogueTrigger>().enabled = true;
            FindObjectOfType<DialogueManager>().endDialogueDelegate = ScoreActivate;
        }

    }

    public void ScoreActivate()
    {
        scorePanel.SetActive(true);
        FindObjectOfType<QuotaManager>().CompleteMandatory();
        int score = int.Parse(scorePanel.GetComponent<TextSetter>().newText.text);
        if(score >= 5){
            GameObject.Find("QuotaExplaination").GetComponent<DialogueTrigger>().enabled = true;
            FindObjectOfType<QuotaManager>().CompleteOpt();
        }else{
            GameObject.Find("Conditon2").GetComponent<DialogueTrigger>().enabled = true;
            FindObjectOfType<DialogueManager>().retryButton.SetActive(true);
            FindObjectOfType<DialogueManager>().nextLevelButton.SetActive(true);
        }
    }


}
