using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragChick : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isDragging = false; 
    public delegate void DragEndedDelegate(Transform transform);
    public DragEndedDelegate dragEndedDelegate;
    public bool isPaused = false; //New line

    private Vector3 offset;
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isDragging && isPaused == false) //Edited line
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + (Vector2)offset;
            GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Foreground");
        }
        if(isDragging)
        {
            transform.GetChild(0).GetComponent<ChickenHitBox>().target = null;
        }
    }

    public void OnMouseDrag()
    {
        isDragging = true;
        


    }

    public void OnMouseDown()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.transform == transform)
        {
            isDragging = true;
            offset = transform.position - (Vector3)mousePosition;  // Calculate the offset
            Debug.Log("Left button is being held down on " + gameObject.name);
           
        }
    }

    public void OnMouseUp()
    {
        Debug.Log("I'm clicking on this chicken");
        isDragging = false;
        if(isPaused == false){
            dragEndedDelegate(this.transform);
        }
        GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Default");
    }

}
