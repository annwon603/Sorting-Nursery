using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncubatorManager : MonoBehaviour
{
    public IncubatorSlot[] listOfIncubators;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //IncubatorSlot test = listOfIncubators[0];
        foreach (IncubatorSlot incubator in listOfIncubators)
        {
            Debug.Log("INCUBATORS " + incubator);
            Debug.Log("NUMBER OF EGGS" + incubator.counter);
        }

    }
}
