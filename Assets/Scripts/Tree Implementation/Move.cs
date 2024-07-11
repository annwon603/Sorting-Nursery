using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject currNode;
    [SerializeField] private float speed = 2.0f; 

    [SerializeField] private Vector2 target;

    [SerializeField] private bool doesTurn = false;

    // Update is called once per frame
    void Update()
    {
        if(doesTurn == false){
            target = currNode.GetComponent<Nodes>().left.getPosition();
        }else{
            target = currNode.GetComponent<Nodes>().right.getPosition();
        }

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Node"){
            currNode = other.gameObject;
            Debug.Log("Tranvesed");
            if(currNode.GetComponent<Nodes>().a == null && currNode.GetComponent<Nodes>().b == null)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; 
            }
        }
        

        // if(other.gameObject.tag == "Chicken"){
        //     doesTurn = true;
        // } 
    }
}

