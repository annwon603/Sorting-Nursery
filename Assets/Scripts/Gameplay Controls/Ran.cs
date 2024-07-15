using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ran : MonoBehaviour
{
    [SerializeField] private int ran;               // Store random integer
    [SerializeField] private bool doesTurn = false; // Decides if chicken should move egg
    
    // Chicken interaction with the egg 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Egg"){
            
            ran = Random.Range(0,2);                
            Debug.Log("Random Value: " + ran);

            if(ran == 1){
                doesTurn = true;
                Debug.Log(gameObject.name + " move egg to right");
            }else{
                doesTurn = false;
                Debug.Log(gameObject.name + " move egg to left");
            }

            other.GetComponent<Move>().doesTurn = doesTurn;
            
        }
    }
}
