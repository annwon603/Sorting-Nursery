using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> snapPoints;
    public List<DragChick> dragScripts;
    public float snapRange = 0.5f;
    void Start()
    {
        foreach(DragChick script in dragScripts)
        {
            
            script.dragEndedDelegate = SnapObject;
        }
    }


    // Update is called once per frame

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

    void Update()
    {
        
    }
}
