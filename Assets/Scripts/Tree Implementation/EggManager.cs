using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggManager : MonoBehaviour
{
    public GameObject[] Eggs;   // List of Eggs to spawn
    GameObject root;            // Starting position
    public float timeToSpawn;   

    int counter = 0;            // Limits how many times egg can spawn

    private float currentTimetoSpawn;
    // Start is called before the first frame update
    void Start()
    {
        root = GameObject.Find("Root");
        // Assign each egg a root node
        foreach(GameObject egg in Eggs)
        {
            egg.GetComponent<Move>().currNode = root; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTimetoSpawn > 0)
        {
            currentTimetoSpawn -= Time.deltaTime;
        } 
        else 
        {
            SpawnObject();
            currentTimetoSpawn = timeToSpawn;
        }
    }

    // Spawn Egg at the root until all eggs are spawn
    public void SpawnObject()
    {
        if(counter < Eggs.Length)
        {
            Instantiate(Eggs[Random.Range(0, Eggs.Length)], root.transform.position, Quaternion.identity);
            counter++;
            Debug.Log("Egg Spawn "+ counter + " times");
        }
        else
        {
            Debug.Log("Out of Eggs");
        }
        
    }
}
