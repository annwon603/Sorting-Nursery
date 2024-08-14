using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LvlManager : MonoBehaviour
{

    //[Header("Events")]
    //public GameEvent testing;
    public DialogueManager dialogueManager;
    public QuotaManager quotaManager;
    public EggManager eggManager;

    public GameObject beginLevel;

    //public GameObject ObjectiveManager;




    // Start is called before the first frame update
    void Start()
    {
        //testing.Raise();
        dialogueManager.endDialogueDelegate = ShowStartButton;

    }

    // Update is called once per frame
    void Update()
    {
        if(Global.CurrentGameState == Global.GameState.ShowObjective)
        {
            dialogueManager.TextBox.SetActive(true);
            quotaManager.quotaPanel.SetActive(false);
            //beginLevel.SetActive(false);

        }else if(Global.CurrentGameState == Global.GameState.Gameplay)
        {
            dialogueManager.TextBox.SetActive(false);
            quotaManager.quotaPanel.SetActive(true);
            // quotaManager.quotaPanel.GetComponent<QuotaTrigger>().enabled = true;
            eggManager.enabled = true;
            CheckIfEggGone();
           
        }else if(Global.CurrentGameState == Global.GameState.Score)
        {
            Debug.Log("You finished");
        }
    }

    void ShowStartButton()
    {
        beginLevel.SetActive(true);
    }

    IEnumerator CheckIfEggGone()
    {
        yield return new WaitForSeconds(0.1f);
        if(GameObject.FindWithTag("Egg") == null)
        {
            Global.CurrentGameState = Global.GameState.Score;
        }
    }




}
