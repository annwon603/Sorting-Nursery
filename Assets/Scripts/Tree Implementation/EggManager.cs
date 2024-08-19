using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggManager : MonoBehaviour
{
    public GameObject[] Eggs;   // List of Eggs to spawn
    GameObject root;            // Starting position
    public float timeToSpawn;   

    public int counter = 0;            // Limits how many times egg can spawn
    //Edit by Harry: made counter public

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

        ShuffleArray(Eggs);

       
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
            Instantiate(Eggs[counter], root.transform.position, Quaternion.identity);
            counter++;
            //Debug.Log("Egg Spawn "+ counter + " times");
        }
        else
        {
            Debug.Log("Out of Eggs");
        }
    }

    void ShuffleArray(GameObject[] array)
    {
        // Fisher-Yates shuffle algorithm (Knuth Shuffle)
        System.Random rng = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            GameObject value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }
}
