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
                bool isunique = isUnique(other.gameObject);
                Debug.Log(other.gameObject.GetInstanceID());
                if (isunique){
                    listOfEggs.Add(other.gameObject);
                }
                counter++;
                other.GetComponent<DragDrop>().finished = true;
                Debug.Log("There are currently " + counter + " eggs in this basket");
            }
            // Check if the basket is full
            if (counter >= eggCapacity)
            {
                isFull = true;
                // Get the Move component of the egg to have the egg to stop moving into the basket
                Move moveComponent = other.gameObject.GetComponent<Move>();
                moveComponent.StopMovement();
                other.gameObject.GetComponent<DragDrop>().isWaiting = true;
                other.gameObject.GetComponent<DragDrop>().resetPosition = other.transform.position;
                if(gameObject.scene.name == "Gameplay")
                {
                    GameObject.Find("Condition").GetComponent<DialogueTrigger>().enabled = true;
                }
            }
        }
    }

    //if the egg did stop and waiting to be dropped into the basket 
    public void OnCollisonStay2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Egg") && other.gameObject.GetComponent<DragDrop>().isWaiting == true)
        {
            if(counter < eggCapacity)
            {
                //other.gameObject.GetComponent<DragDrop>().finished = true;
                Debug.Log("Egg that is waiting dropped in");
                bool isunique = isUnique(other.gameObject);
                Debug.Log(other.gameObject.GetInstanceID());
                if (isunique){
                    listOfEggs.Add(other.gameObject);
                }
                other.gameObject.GetComponent<DragDrop>().finished = true;
                other.gameObject.GetComponent<DragDrop>().isWaiting = false;
                counter++;
                //counter++;
            }
        }
    }

    bool isUnique(GameObject egg)
    {
        //If the list doesn't have that egg yet
        if(!listOfEggs.Contains(egg))
        {
            return true;
        }

        //If list does contain that egg type, need to check if the InstanceID is the same
        if(listOfEggs.Contains(egg))
        {
            int id = egg.gameObject.GetInstanceID();
            if(Resources.InstanceIDIsValid(id) == false)
            {
                return true;
            }
            foreach(var item in listOfEggs)
            {
                if(Resources.InstanceIDIsValid(item.GetInstanceID()) == false)
                {
                    return true;
                }
                if(item.gameObject.GetInstanceID() == id)
                {
                    return false;
                }
            }
            return true;
        }

        Debug.Log("Invalid");
        return false;

    }

    

}
