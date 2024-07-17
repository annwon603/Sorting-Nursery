using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ran : MonoBehaviour
{
    [SerializeField] private float ran;             // Store random integer
    [SerializeField] private bool doesTurn = false; // Decides if chicken should move egg

    public Traits ChickTrait; // The Trait it was assigned

    [SerializeField] private bool doesMatch;        //Check if egg match chicken
    // Chicken interaction with the egg 
    [Range(0.0f , 1.0f)]
    public float adjustProp;       //  Adjusting Probablity for chicken to mess up

    private void Start()
    {
        adjustProp = 0.2f;        //Default probablity is 20%
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Egg"){
            
            ran = Random.value * 100;                
            Debug.Log(gameObject.name + " Random Value: " + ran);
            
            bool ranBool = ProbabilityCheck(ran);
            Debug.Log(gameObject.name + " Is Random: " + ranBool);

            DragDrop egg = other.gameObject.GetComponent<DragDrop>();
            bool doesMatch = traitCheck(egg.trait.isTraitActive, egg.trait.traitSet);
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

    public bool ProbabilityCheck(float ranVal)
    {
        int probablity = (int)adjustProp * 100;
        if (ranVal <= adjustProp)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool traitCheck(bool trait, string traitSet)
    {
        //First it checks if the boolean value "isTraitActive" of both chicken
        //and egg matches. Then it checks if both strings matches
        bool match = ((ChickTrait.isTraitActive && trait) || 
                    !(ChickTrait.isTraitActive || trait));
        return match && (ChickTrait.traitSet == traitSet);
    }
}
