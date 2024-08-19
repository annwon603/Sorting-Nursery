using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    [SerializeField] private bool isDragging = false; 

    public bool finished ; //check if egg is in the basket

    public bool isWaiting;

    public Vector3 resetPosition; 

    //private Color originalColor;
    //private Color hover; //Intereaction for player to see if egg is hover over the box

    public Traits trait;
    public bool isPaused = false; //New line
    public Traits size;

    public Traits pattern;

    public Traits color;

    public Traits texture;
    void Start()
    {
        //resetPosition = this.transform.localPosition;
    }

    void Update()
    {
        if(finished)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            isDragging = false;
            //resetPosition = this.transform.localPosition;
        }
        if(isDragging && isPaused == false) //Edited line
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
        
    }

    public void OnMouseDrag()
    {
        //if(gameObject.scene.name == "Gameplay" || gameObject.scene.name == "Tutorial2" ){
            // If the egg stop moving if it encountered a filled basket, egg now draggable
        if(GetComponent<Move>().doesMove == false)
        {
            isDragging = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        //}
        // isDragging = true;
        // if (!GetComponent<Move>().enabled)
        // {
        //  return;
        // }
        // if(GetComponent<Move>().doesMove == false)
        // {
        //     GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //     GetComponent<Move>().enabled = false;
        // }
        // if(GetComponent<Move>().doesMove == false)
            // {
            //     isDragging = true;
            // }
        
        //isDragging = true;
    }

    public void OnMouseUp()
    {     
        isDragging = false;
        Vector3 compare = new Vector3(0.0f,0.0f,0.0f);
        if(resetPosition != compare)
        {
            transform.position = resetPosition;
        }
       
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        // if(finished == true)
        // {
        //     Debug.Log("In the box");
        //     gameObject.SetActive(false);
        // } else {
        //     this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        // }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Basket"))
        {
            resetPosition = other.transform.position;
            Debug.Log("Reset Position now at " + other.name);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Node"))
        {
            Debug.Log("Away from node");
            
        }
    }



}
