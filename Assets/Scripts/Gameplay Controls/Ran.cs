using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ran : MonoBehaviour
{
    public enum TraitType  //Type of trait catergory the chicken needs to check for
    {
        Colors,   // 0
        Patterns, // 1
        Sizes,    // 2
        Texture   // 3
    }  

    public TraitType traitType; 
    [SerializeField] private float ranDom;             // Store random integer
    public bool doesTurn = false; // Decides if chicken should move egg

    public Traits ChickTrait;                       // The Trait it was assigned

    [SerializeField] private bool doesMatch;        // Check if egg match chicken
    
    [Range(0.0f , 1.0f)]
    public float adjustProp;                        // Adjusting Probablity for chicken to mess up

    [SerializeField] private bool ranBool;

    private void Start()
    {
        adjustProp = 0.25f;        //Default probablity is 20%
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        //If it detects an Egg that reached the node the chicken is currently at
        if(other.gameObject.tag == "Egg"){
            
            ranDom = Random.value * 100;                
            Debug.Log(gameObject.name + " Random Value: " + ranDom);
            
            ranBool = ProbabilityCheck(ranDom);
            Debug.Log(gameObject.name + " Is Random: " + ranBool);

            DragDrop egg = other.gameObject.GetComponent<DragDrop>();
            doesMatch = traitCheck2(traitType,egg);
            //bool doesMatch = traitCheck(egg.trait.isTraitActive, egg.trait.traitSet);
            Debug.Log(gameObject.name + " does match: " + doesMatch);

            if(doesMatch ^ ranBool == true){
                doesTurn = true;
                Debug.Log(gameObject.name + " "+ ChickTrait.traitSet+ " move " + egg.trait.traitSet+ " egg to right");
            }else{
                doesTurn = false;
                Debug.Log(gameObject.name + " move egg to left");
            }

            other.GetComponent<Move>().doesTurn = doesTurn;
            
        }
    }

    //Compares the random number the chicken generated and the percentage 
    //we set the probablity
    public bool ProbabilityCheck(float ranVal)
    {
        float probablity = adjustProp * 100;
        if(ranVal <= probablity)
        {
            return true;
        } else {
            return false;
        }
    }


    // Determines which trait of the egg to check for corresponding to chicken trait category
    public bool traitCheck2(TraitType traitType, DragDrop egg)
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
                Debug.Log("traitCheck2 failed");
                break;
        }

        bool match = (ChickTrait.isTraitActive && eggTrait.isTraitActive) || 
                    !(ChickTrait.isTraitActive || eggTrait.isTraitActive);
                    
        return match && (ChickTrait.traitSet == eggTrait.traitSet);
    }

    //First it checks if the boolean value "isTraitActive" of both chicken
    //and egg matches. Then it checks if both strings matches
    // public bool traitCheck(bool trait, string traitSet)
    // {
    //     bool match = ((ChickTrait.isTraitActive && trait) || 
    //                 !(ChickTrait.isTraitActive || trait));
    
    //     return match && (ChickTrait.traitSet == traitSet);
    // }
}
