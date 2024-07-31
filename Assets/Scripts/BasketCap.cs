using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketCap : MonoBehaviour
{
    // Start is called before the first frame update
    public int eggCapacity;
    public bool isFull = false;
    [SerializeField] private int counter = 0;

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

        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Egg"))
        {
            // Check for trigger collision and if the basket is not full
            if (other.isTrigger && counter < eggCapacity)
            {
                ++counter;
                Debug.Log("There are currently " + counter + " eggs in this basket");
            }
            // Check if the basket is full
            if (counter >= eggCapacity)
            {
                isFull = true;
                // Get the Move component of the egg to have the egg to stop moving into the basket
                Move moveComponent = other.gameObject.GetComponent<Move>();
                moveComponent.StopMovement();
                if(FindObjectOfType<LeverSwitch>() != null)
                {
                    FindObjectOfType<LeverSwitch>().Switch(); 
                }
            }
        }
    }

}
