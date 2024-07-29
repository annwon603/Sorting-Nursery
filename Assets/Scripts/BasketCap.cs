using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketCap : MonoBehaviour
{
    // Start is called before the first frame update
    public int eggCapacity;
    public bool isFull = false;
    int counter = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Egg" && other.isTrigger == true && counter < eggCapacity)
        {
            ++counter;
            Debug.Log("There is current " + counter + " eggs in this basket");

        }else if(other.gameObject.tag == "Egg" && counter >= eggCapacity)
        {
            // Debug.Log("Basket is Full");
            other.gameObject.GetComponent<Move>().enabled = false;
            isFull = true;
            Debug.Log(other.gameObject.name + " should stop moving");
        }

    }
}
