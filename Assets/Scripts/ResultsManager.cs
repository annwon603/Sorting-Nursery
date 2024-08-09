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
        // foreach (IncubatorSlot incubator in listOfIncubators)
        // {
        //     Debug.Log("NUMBER OF EGGS" + incubator.counter); //testing line
        // }

        int totalEggs = 0;

        foreach (IncubatorSlot incubator in listOfIncubators)
        {
            totalEggs += incubator.counter;
        }
        Debug.Log("TOTAL NUMBER OF EGGS: " + totalEggs); 
    }
}