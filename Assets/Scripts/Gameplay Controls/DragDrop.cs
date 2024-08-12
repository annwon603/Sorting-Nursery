using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    [SerializeField] private bool isDragging = false; 

    public bool finished ; //check if egg is in the basket

    private Vector3 resetPosition; 

    private Color originalColor;
    private Color hover; //Intereaction for player to see if egg is hover over the box

    public Traits trait;
    public bool isPaused = false; //New line
    public Traits size;

    public Traits pattern;

    public Traits color;

    public Traits texture;
    void Start()
    {
        resetPosition = this.transform.localPosition;
        // Debug.Log("" + resetPosition.x);
        // originalColor = correctForm.GetComponent<SpriteRenderer>().color;
        hover = originalColor;
        hover.a = 0.9f;
        
    }

    void Update()
    {
        if(finished)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        if(isDragging && isPaused == false) //Edited line
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
    }

    public void OnMouseDrag()
    {
        if(gameObject.scene.name == "Gameplay" || gameObject.scene.name == "Tutorial2"){
            // If the egg stop moving if it encountered a filled basket, egg now draggable
            if(GetComponent<Move>().doesMove == false)
            {
                isDragging = true;
            }
        }
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
    }

    public void OnMouseUp()
    {
        isDragging = false;
        // if(finished == true)
        // {
        //     Debug.Log("In the box");
        //     gameObject.SetActive(false);
        // } else {
        //     this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        // }


    }



}
