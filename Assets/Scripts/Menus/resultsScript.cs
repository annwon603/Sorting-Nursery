using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resultsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //When level is completed
    }

    // public void Level2()
    // {
    //     SceneManager.LoadScene("Level2");
    // }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
