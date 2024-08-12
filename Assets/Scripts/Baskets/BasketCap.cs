using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasketCap : MonoBehaviour
{
    // Start is called before the first frame update
    public int eggCapacity;
    public bool isFull = false;
    public int counter = 0;

    public List<GameObject> listOfEggs;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(counter >= eggCapacity)
        {
            isFull = true;
        }

        // Checks if there is missing eggs aka check if any egg went into the incubator
        for(int i = listOfEggs.Count - 1; i >= 0; i--){
            if(listOfEggs[i] == null){
                listOfEggs.RemoveAt(i);
            }
        }

        counter = listOfEggs.Count;
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Egg"))
        {
            // Check for trigger collision and if the basket is not full
            if (other.isTrigger && counter < eggCapacity)
            {
                counter++;
                listOfEggs.Add(other.gameObject);
                Debug.Log("There are currently " + counter + " eggs in this basket");
            }
            // Check if the basket is full
            if (counter >= eggCapacity)
            {
                isFull = true;
                // Get the Move component of the egg to have the egg to stop moving into the basket
                Move moveComponent = other.gameObject.GetComponent<Move>();
                moveComponent.StopMovement();
                if(gameObject.scene.name == "Gameplay")
                {
                    GameObject.Find("Condition").GetComponent<DialogueTrigger>().enabled = true;
                }
                
            }
        }
    }

    //if the egg did stop and waiting to be dropped into the basket 
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Egg"))
        {
            if(other.isTrigger && counter < eggCapacity)
            {
                other.gameObject.GetComponent<DragDrop>().finished = true;
            }
        }
    }

    

}
