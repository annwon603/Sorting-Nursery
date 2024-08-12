using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenHitBox : MonoBehaviour
{
    public Transform target;  // Reference to the object you want to follow

    void Update()
    {
        if (target != null)
        {
            // Set the position of the current object to the target's position
            transform.position = target.position;
        }
    }
}
