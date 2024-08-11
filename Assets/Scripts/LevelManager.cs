using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public GameObject scorePanel;

    public GameObject QuotaPanel;

    public DialougeHover dialougeHover;
  
   void Update()
   {

        if(FindObjectOfType<DialogueManager>().counter == 2)
        {
            Destroy(GameObject.Find("EggShellBG"));
           Activate();
        }

        if(FindObjectOfType<DialogueManager>().counter == 5)
        {
           EggSpawn();
           
        }

        if(FindObjectOfType<DialogueManager>().counter == 6)
        {
            if(FindObjectOfType<BasketManager>().areAllFull)
           {
                // FindObjectOfType<DialogueManager>().showButton();
                GameObject.Find("Task").GetComponent<DialogueTrigger>().enabled = true;
                FindObjectOfType<BasketManager>().Activate();
           }
            // FindObjectOfType<DialogueManager>().showButton();
        }

        if(FindObjectOfType<DialogueManager>().counter == 7)
        {
            if(FindObjectOfType<BasketPage>() != null)
            {
                FindObjectOfType<DialogueManager>().showButton();
            }
            
            dialougeHover.canDisappear = true;

        }
        
        if(FindObjectOfType<DialogueManager>().counter > 7){
            dialougeHover.canDisappear = false;
        }

        if(FindObjectOfType<DialogueManager>().counter == 9 && GameObject.FindWithTag("Egg") == null)
        {
            FindObjectOfType<DialogueManager>().showButton();

        }

        if(FindObjectOfType<DialogueManager>().counter == 10)
        {
           FindObjectOfType<DialogueManager>().endDialogueDelegate = ScoreActivate;
        }

        if(FindObjectOfType<DialogueManager>().counter == 14)
        {
            FindObjectOfType<DialogueManager>().endDialogueDelegate = null;
            FindObjectOfType<DialogueManager>().endDialogueDelegate = GoNextLevel;
        }




   }

    private void Activate() 
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject.tag == "TutorialTask1")
            {
                transform.GetChild(i).gameObject.SetActive(true);
                Debug.Log(transform.GetChild(i).gameObject.name + " got activated");
            }
        }

        QuotaPanel.SetActive(true);
    }

    private void EggSpawn()
    {
        FindObjectOfType<EggManager>().enabled = true;
        FindObjectOfType<BasketManager>().enabled = true;
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

    public void Retry()
    {
        SceneManager.LoadScene("Gameplay");
        
    }

    public void GoNextLevel()
    {
        SceneManager.LoadScene("Tutorial2");
    }

    

    


}
