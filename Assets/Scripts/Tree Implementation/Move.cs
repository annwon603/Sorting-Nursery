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

    // Update is called once per frame
    void Update()
    {
        if(doesTurn == false)
        {
            target = currNode.GetComponent<Nodes>().left.getPosition();
        } else {
            target = currNode.GetComponent<Nodes>().right.getPosition();
        }

        
        if(GetComponent<DragDrop>().finished == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }


    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Switches currentNode to the node it interact with
        if(other.gameObject.tag == "Node"){
            currNode = other.gameObject;
            Debug.Log("Tranvesed at " + other.gameObject.name);

            //If the currentNode doesn't have any children, that means it reached to the basket
            if(currNode.GetComponent<Nodes>().a == null && currNode.GetComponent<Nodes>().b == null)
            {
                GetComponent<DragDrop>().finished = true;
                Debug.Log("Reached Basket");
            }

            changedNode = true;
        }
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        changedNode = false;
        //Debug.Log("ChangedNode " + changedNode);
    }

    public void StopMovement()
    {
        doesMove = false;
        
    }

    public void Movement()
    {
        if(doesTurn == false)
        {
            target = currNode.GetComponent<Nodes>().left.getPosition();
        } else {
            target = currNode.GetComponent<Nodes>().right.getPosition();
        }

        if(GetComponent<DragDrop>().finished == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
}

