using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> snapPoints;  //Places to snap the chicken in place
    public List<DragChick> dragScripts; //Scripts that are attached to the chicken object 
    public float snapRange = 0.5f;
    void Start()
    {
        // Make a reference to the delegate in the DragChick script and assign it to SnapObject function
        foreach(DragChick script in dragScripts)
        {
            
            script.dragEndedDelegate = SnapObject;
        }
    }


    // If the chicken is less than or equal to the range, it changes position to the snap position I assign
    public void SnapObject(Transform obj)
    {
        foreach(Transform point in snapPoints)
        {
            if (Vector2.Distance(point.position,obj.position) <= snapRange)
            {
                obj.position = point.position;
                return;
            }
        }
    }

}
