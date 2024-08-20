using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGround
{
    //Dragons are special, only achieve from optional obj
    //Dinos achieved from mandatory objective
    public static int numOfDragons = 0;
    
    public static int numOfDinos = 0;

    public static void IncreaseDinoScore()
    {
        numOfDinos++;
        Debug.Log(numOfDinos + " dinos will appear in the PlayGround");
    }

    public static void IncreaseDragonScore()
    {
        numOfDragons++;
        Debug.Log(numOfDragons + " dragon will appear in the PlayGround");
    }
    
}
