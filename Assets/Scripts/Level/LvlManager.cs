using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{

    //[Header("Events")]
    //public GameEvent testing;
    public DialogueManager dialogueManager;
    public QuotaManager quotaManager;

    public ObjectiveManager objectiveManager;
    public EggManager eggManager;

    public GameObject scorePanel;

    public GameObject beginLevel;

    [SerializeField]
    private string nextLevelName;

    // Start is called before the first frame update
    void Start()
    {
        //testing.Raise();
        Global.CurrentGameState = Global.GameState.ShowObjective;
        dialogueManager.endDialogueDelegate = ShowStartButton;

    }

    // Update is called once per frame
    void Update()
    {
        if(Global.CurrentGameState == Global.GameState.ShowObjective)
        {
            dialogueManager.TextBox.SetActive(true);
            quotaManager.quotaPanel.SetActive(false);
            Debug.Log("I'm in ShowObjective State");
            //beginLevel.SetActive(false);

        }else if(Global.CurrentGameState == Global.GameState.Gameplay)
        {
            dialogueManager.TextBox.SetActive(false);
            quotaManager.quotaPanel.SetActive(true);
            // quotaManager.quotaPanel.GetComponent<QuotaTrigger>().enabled = true;
            Debug.Log("I'm in Gameplay State");
            eggManager.enabled = true;
            StartCoroutine(CheckIfEggGone());
    
        }else if(Global.CurrentGameState == Global.GameState.Score)
        {
            scorePanel.SetActive(true);
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
            Debug.Log("Eggs are gone");
        }
    }

    IEnumerator CheckIfCompleteManObj()
    {
        yield return null;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }





}
