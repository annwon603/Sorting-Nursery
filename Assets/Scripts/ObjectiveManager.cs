using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI manObjtext;
    public TextMeshProUGUI optObjtext;

    public GameObject objMenu;

    void Start()
    {
        
    }

    public void SetObjective(Objective objective)
    {
        manObjtext.text = objective.manObj.dialouge;
        optObjtext.text = objective.optObj.dialouge;
    }

}
