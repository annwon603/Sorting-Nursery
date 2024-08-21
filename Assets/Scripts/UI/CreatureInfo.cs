using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreatureInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public CreatureFact creatureFact;
    
    public TextMeshProUGUI creatureName;
    public TextMeshProUGUI creatureDescription;


    public void OnMouseDown()
    {
        
        creatureName.text = creatureFact.creatureName;
        creatureDescription.text = creatureFact.description;
    }
}
