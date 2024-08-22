using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class LvlManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public QuotaManager quotaManager;
    public ObjectiveManager objectiveManager;
    public EggManager eggManager;
    public GameObject scorePanel;
    public resultsScript Result;
    public GameObject beginLevel;

    
    public FMODUnity.EventReference CompleteMan;
    public FMODUnity.EventReference CompleteObj;



    [SerializeField]
    Objective objective;

    [SerializeField]
    private string nextLevelName;

    bool justIncreaseDinoScore = false;
    bool justIncreaseDragonScore = false;

    // Start is called before the first frame update
    void Start()
    {
        //testing.Raise();
        Global.CurrentGameState = Global.GameState.ShowObjective;
        dialogueManager.endDialogueDelegate = ShowStartButton;
        
        objective = objectiveManager.objMenu.GetComponent<ObjectiveTrigger>().objective;

    }

    // Update is called once per frame
    void Update()
    {
        if(Global.CurrentGameState == Global.GameState.ShowObjective)
        {
            dialogueManager.TextBox.SetActive(true);
            quotaManager.quotaPanel.SetActive(false);
            //Debug.Log("I'm in ShowObjective State");
            //beginLevel.SetActive(false);

        }else if(Global.CurrentGameState == Global.GameState.Gameplay)
        {
            dialogueManager.TextBox.SetActive(false);
            quotaManager.quotaPanel.SetActive(true);
            // quotaManager.quotaPanel.GetComponent<QuotaTrigger>().enabled = true;
            //Debug.Log("I'm in Gameplay State");
            eggManager.enabled = true;
            StartCoroutine(CheckIfCompleteObj());

    
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
        yield return new WaitForSeconds(3.0f);
        if(GameObject.FindWithTag("Egg") == null)
        {
            Global.CurrentGameState = Global.GameState.Score;
            Debug.Log("Eggs are gone");
        }
    }

    IEnumerator CheckIfCompleteObj()
    {
        yield return null;
        
        List<GameObject> IncabatorA = new List<GameObject>(Result.listOfIncubators[0].EgginIncubator);
        List<GameObject> IncabatorB = new List<GameObject>(Result.listOfIncubators[1].EgginIncubator);;

        //Mandatory Objective checks how many eggs of type ___ is in the incubator 
        //overall regardless if it's right or wrong 
        //Optional Objective checks for correctness
        Obj man = objective.manObj;     
        Obj opt = objective.optObj;     

        int requiredManEggs = man.numOfEggs;
        int reqeuiredoptEggs = opt.numOfEggs;

        TraitType requiredManType = man.eggType;
        TraitType requiredOptType = opt.eggType;

        Traits requiredManTrait = man.typeOfEgg;
        Traits requiredOptTrait = opt.typeOfEgg;
        Traits IncubatorATrait = Result.listOfIncubators[0].IncuTrait;   //Dragon
        Traits IncubatorBTrait = Result.listOfIncubators[1].IncuTrait;   //Dino
        bool needCorrect = man.needCorrect;
        
        int currManEggs = 0;
        int currOptEggs = 0;

        foreach(var egg in IncabatorA)
        {
            Traits eggTrait = egg.GetComponent<DragDrop>().trait;       //Getting Dino or Dragon Trait from egg
            Traits eggTypeTrait = SearchTypeCategory(requiredManType, egg.GetComponent<DragDrop>());
            Traits eggTypeTraitOpt = SearchTypeCategory(requiredOptType, egg.GetComponent<DragDrop>());
            //If the requireManTrait is null that means anytype, egg match the mandatory trait, or match the incubator
            if(needCorrect == true)
            {
                if(eggTrait == IncubatorATrait || eggTypeTrait == requiredManTrait)
                {
                    currManEggs++;
                }
            } else if( requiredManTrait == null || eggTrait == IncubatorATrait || eggTypeTrait == requiredManTrait)
            {
                currManEggs++;
            }

            //If OptTrait is null that means any tyep, but need to check if egg match incubator trait
            //Or check if egg is sorted correctly and match the opt trait
            if ((requiredOptTrait == null && eggTrait == IncubatorATrait) ||
                (eggTypeTraitOpt == requiredOptTrait && eggTrait == IncubatorATrait))
            {
                currOptEggs++;
            }
        }

        foreach(var egg in IncabatorB)
        {
            Traits eggTrait = egg.GetComponent<DragDrop>().trait;         
            Traits eggTypeTrait = SearchTypeCategory(requiredManType, egg.GetComponent<DragDrop>());
            Traits eggTypeTraitOpt = SearchTypeCategory(requiredOptType, egg.GetComponent<DragDrop>());
            //If the requireManTrait is null that means anytype, egg match the mandatory trait, or match the incubator
            if(needCorrect == true)
            {
                if(eggTrait == IncubatorBTrait || eggTypeTrait == requiredManTrait)
                {
                    currManEggs++;
                }
            } else if( requiredManTrait == null || eggTrait == IncubatorBTrait || eggTypeTrait == requiredManTrait)
            {
                currManEggs++;
            }

            //If OptTrait is null that means any tyep, but need to check if egg match incubator trait
            //Or check if egg is sorted correctly and match the opt trait
            if ((requiredOptTrait == null && eggTrait == IncubatorBTrait) ||
                (eggTypeTraitOpt == requiredOptTrait && eggTrait == IncubatorBTrait))
            {
                currOptEggs++;
            }
        }

        Debug.Log("Current Optional Eggs:" + currOptEggs);
        Debug.Log("Required Optional Eggs:" + reqeuiredoptEggs);

        if(currManEggs >= requiredManEggs)
        {
            quotaManager.CompleteMandatory();

            if(justIncreaseDinoScore == false)
            {
                PlayGround.IncreaseDragonScore();
                justIncreaseDinoScore = true;
                FMODUnity.RuntimeManager.PlayOneShot(CompleteMan);
            }
            
        }

        if(currOptEggs >= reqeuiredoptEggs)
        {
            quotaManager.CompleteOpt();

            if(justIncreaseDragonScore == false)
            {
                PlayGround.IncreaseDinoScore();
                justIncreaseDragonScore = true;
                FMODUnity.RuntimeManager.PlayOneShot(CompleteObj);
            }
        }

        if(IncabatorA.Count + IncabatorB.Count == eggManager.Eggs.Length)
        {
            StartCoroutine(CheckIfEggGone());
        }

    }

    Traits SearchTypeCategory(TraitType traitType, DragDrop egg)
    {
        Traits eggTrait = null;
        switch(traitType)
        {
            case TraitType.Colors:
                eggTrait = egg.color;
                break;
            case TraitType.Sizes:
                eggTrait = egg.size;
                break;
            case TraitType.Patterns:
                eggTrait = egg.pattern;
                break;
            case TraitType.Texture:
                eggTrait = egg.texture;
                break;
            default:
                Debug.Log("No Trait Category");
                break;
        }

        return eggTrait;

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

}
