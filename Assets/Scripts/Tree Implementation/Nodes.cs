using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Node left; // Left child node
    public GameObject a; // Attached to the left child node

    public Node right; // Right child node

    public GameObject b; // Attached to the right child node

    [System.Serializable]
    public struct Node{
        public Vector2 pos; // Stores in location of the gameobject

        // Constructor to initialize the position to the passing gameobject
        public Node(GameObject o) 
        {
            pos = o.transform.position;
        }

        public Vector2 getPosition()
        {
            return pos;
        }
    }

    void Start()
    {
        if(a != null){
            left = new Node(a);
            Debug.Log(gameObject.name + " have left child");
        }else{
            Debug.Log(gameObject.name + " don't left child");
        }
        // If the node have a right child, initialize Node right otherwise output "don't have child" 
        if(b != null){
            right = new Node(b);
            Debug.Log(gameObject.name + " have right child");
        }else{
            Debug.Log(gameObject.name + " don't have right child");
        }

    }

    

}


