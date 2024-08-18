using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Objective", menuName = "Obj")]
public class Obj : ScriptableObject
{
    public Text objText; // Display the objective 

    public int numOfEggs;  // How many eggs to fulfill that objective

    public Traits typeOfEgg; // What type of egg to fulfill that objective 

    public TraitType eggType; // What catoergy of type to search for
}
