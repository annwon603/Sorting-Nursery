using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D normal;
    public Collider2D turn;

    // bool isChickenThere = false;

    void Start()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
    //    foreach (ContactPoint2D contact in other.contacts)
    //    {
    //         Debug.Log(contact.collider.name + " hit " + contact.otherCollider.name);
    //         Debug.DrawRay(contact.point, contact.normal, Color.white);
    //    }
        Debug.Log("I detect " + other.gameObject.name);
        normal.enabled = false;
        turn.enabled = true;
        // isChickenThere = true;
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " exited");
        // isChickenThere = false;
        normal.enabled = true;
        turn.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        // if(isChickenThere == false){
        //     normal.enabled = true;
        // }
    }
}
