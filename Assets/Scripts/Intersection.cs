using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
    //    foreach (ContactPoint2D contact in other.contacts)
    //    {
    //         Debug.Log(contact.collider.name + " hit " + contact.otherCollider.name);
    //         Debug.DrawRay(contact.point, contact.normal, Color.white);
    //    }
        Debug.Log("I detect " + other.gameObject.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
