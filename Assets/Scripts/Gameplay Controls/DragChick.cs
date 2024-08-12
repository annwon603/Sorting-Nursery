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
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isDragging && isPaused == false) //Edited line
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Foreground");
        }
    }

    public void OnMouseDrag()
    {
        isDragging = true;

    }

    public void OnMouseUp()
    {
        isDragging = false;
        if(isPaused == false){
            dragEndedDelegate(this.transform);
        }
        GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Default");
    }

}
