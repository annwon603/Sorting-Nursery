using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class resultsScript : MonoBehaviour
{
    public GameObject ResultsMenu;
    public TMP_Text EggsSortedCorrect;
    public TMP_Text TotalEggs;
    public TMP_Text AccuracyNumber;
    //private IncubatorManager eggsDroppedInIncubator;
    private EggManager eggsInLevel;
    public IncubatorSlot[] listOfIncubators;

    // Start is called before the first frame update
    void Start()
    {
        ResultsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // print("Eggs dropped: " + eggsDroppedInIncubator.totalEggs);
        //print("Eggs in level: " + eggsInLevel.counter);
        // // if (eggsDroppedInIncubator.totalEggs == eggsInLevel.counter) {
        // //     ShowResultsMenu();
        // // }
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

    public void ShowResultsMenu() {
        ResultsMenu.SetActive(true);
        GameObject.Find("Canvas").GetComponent<pauseScript>().enabled = false;
        Time.timeScale = 0f;
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
