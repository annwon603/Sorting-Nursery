using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[System.Serializable] // allow to make edits from the editor

// Cannot derive from monobehavior or else we need to attach it to a game object
public class Dialogue
{
    public string name; //name of the npc that is talking

    [TextArea(3,10)]
    public string[] sentences;  //List of dialouges
    
}
