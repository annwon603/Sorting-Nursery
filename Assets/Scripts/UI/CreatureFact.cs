using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Creature", menuName = "Creature")]
public class CreatureFact : ScriptableObject
{
   
   public string creatureName;

[TextArea(3,10)]
   public string description;
}
