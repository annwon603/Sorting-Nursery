using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DnDSpawn : MonoBehaviour
{
    public List<GameObject> Dino;
    public List<GameObject> Dragon;

    public int dragonsToSpawn;

    public int dinoToSpawn;
    void Start()
    {
        dragonsToSpawn = PlayGround.numOfDragons;
        dinoToSpawn = PlayGround.numOfDinos;

        for(int i = 0; i < dragonsToSpawn; i++)
        {
            Dragon[i].SetActive(true);
        }
         for(int i = 0; i < dinoToSpawn; i++)
        {
            Dino[i].SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
