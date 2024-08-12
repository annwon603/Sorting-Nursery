using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Text", menuName = "Texts")]
public class Text : ScriptableObject
{

    [TextArea(3,10)]
    public string dialouge; //Store in dialogue

    public bool needTaskComplete; // Is it conditional? If false then can move to next text,
                                     // If true, then need to complete a task to move to next text; 
}