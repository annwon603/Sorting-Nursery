using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ran : MonoBehaviour
{
    [SerializeField] private float ran;             // Store random integer
    [SerializeField] private bool doesTurn = false; // Decides if chicken should move egg
        
    [SerializeField] private bool isBig;            // Set trait of chicken

    [SerializeField] private bool doesMatch;        //Check if egg match chicken
    // Chicken interaction with the egg 

    [SerializeField] private int adjustProp;       //  Adjusting Probablity for chicken to mess up

    private void Start()
    {
        adjustProp = 20;        //Default probablity is 20%
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Egg"){
            
            ran = Random.value * 100;                
            Debug.Log(gameObject.name + " Random Value: " + ran);
            
            bool ranBool = ProbabilityCheck(ran);
            bool doesMatch = traitCheck(other.gameObject.GetComponent<DragDrop>().egg.Big);
            Debug.Log(gameObject.name + " Is Random: " + ranBool);
            Debug.Log(gameObject.name + " does match: " + doesMatch);

            if(doesMatch ^ ranBool == true){
                doesTurn = true;
                Debug.Log(gameObject.name + " move egg to right");
            }else{
                doesTurn = false;
                Debug.Log(gameObject.name + " move egg to left");
            }

            other.GetComponent<Move>().doesTurn = doesTurn;
            
        }
    }

    public bool ProbabilityCheck(float ranVal)
    {
        if (ranVal <= adjustProp)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool traitCheck(bool size)
    {
        bool match = (size && isBig);
        return match;
    }
}
