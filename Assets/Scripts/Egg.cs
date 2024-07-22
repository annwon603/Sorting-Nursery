using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Egg", menuName = "Egg")]
public class Egg : ScriptableObject
{
    public bool Big;        //big vs small trait
    public bool Small;      //Metallic vs nonmetallic

}
