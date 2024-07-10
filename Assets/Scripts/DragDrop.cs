using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    [SerializeField] private bool isDragging = false; 

    public bool finished ; //check if egg is in the box

    private Vector3 resetPosition; 

    private Color originalColor;
    private Color hover; //Intereaction for player to see if egg is hover over the box

    public Egg egg;
    void Start()
    {
        resetPosition = this.transform.localPosition;
        Debug.Log("" + resetPosition.x);
        // originalColor = correctForm.GetComponent<SpriteRenderer>().color;
        hover = originalColor;
        hover.a = 0.9f;
        
    }

    private void Awake(){
        // canvasGroup = GetComponent<CanvasGroup>();
    }
    void Update()
    {
        if(isDragging)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
        
    }

    public void OnMouseDrag()
    {
        isDragging = true;
        // Detecting if the item is within the box 

        // if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 1.5f &&
        //     Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 1.5f)
        // {
        //     Debug.Log("At the box");
        //     correctForm.GetComponent<SpriteRenderer>().color = hover;
        //     finished = true;
            
        // }
        // else
        // {
        //     Debug.Log("Not in the box");
        //     correctForm.GetComponent<SpriteRenderer>().color = originalColor;
        //     finished = false; 
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
