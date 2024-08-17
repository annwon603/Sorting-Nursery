using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject currNode; 
    [SerializeField] private float speed = 2.0f; 

    [SerializeField] private Vector2 target;    //Destination for egg to go to

    public bool doesTurn = false;               //Determines whether egg turn left or right

    public bool changedNode = false;

    public bool doesMove = true;

    public bool isNearChicken = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(doesMove == true)
        {
            //StartCoroutine(MovementDelay());
            Movement();
        }


    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Chicken"))
        {
            isNearChicken = true;
        }
        //Switches currentNode to the node it interact with
        if(other.gameObject.tag == "Node"){
            currNode = other.gameObject;
            Debug.Log("Tranvesed at " + other.gameObject.name);

            //If the currentNode doesn't have any children, that means it reached to the basket
            if(currNode.GetComponent<Nodes>().a == null && currNode.GetComponent<Nodes>().b == null && currNode.GetComponent<BasketCap>().isFull == false)
            {
                GetComponent<DragDrop>().finished = true;
                Debug.Log("Reached Basket");
            }

            changedNode = true;

            StartCoroutine(CheckTwoTrigger());
        }


        
    }

    IEnumerator CheckTwoTrigger()
    {
        if((changedNode && isNearChicken) == false)
        {
            yield return null;
    
            doesTurn = false;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        changedNode = false;
        //Debug.Log("ChangedNode " + changedNode);
        isNearChicken = false;

    }

    

    public void StopMovement()
    {
        doesMove = false;

        Debug.Log("Stop Moving");
    }


    public void Movement()
    {
        if(doesTurn == true)
        {
            target = currNode.GetComponent<Nodes>().right.getPosition();
        } else {
            target = currNode.GetComponent<Nodes>().left.getPosition();
        }

        if(GetComponent<DragDrop>().finished == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
}

