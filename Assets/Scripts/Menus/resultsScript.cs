using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class resultsScript : MonoBehaviour
{
    public GameObject ScorePanel;
    public TMP_Text EggsSortedCorrect;
    public TMP_Text TotalEggs;
    public TMP_Text AccuracyNumber;
    //private IncubatorManager eggsDroppedInIncubator;
    private EggManager eggsInLevel;
    public IncubatorSlot[] listOfIncubators;

    public GameObject PauseButton;
    public GameObject TextBox;
    public GameObject QuotaPanel;

    public TMP_Text AYes;
    public TMP_Text ANo;
    public TMP_Text BYes;
    public TMP_Text BNo;

    // Start is called before the first frame update
    void Start()
    {
        ScorePanel.SetActive(false);
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
        // //Debug.Log("There are " + Eggs.Length + " in level"); //Test
        // Debug.Log("There are aaaaaa" + eggsInLevel.Eggs.Length + " in level");

        // if (totalEggs == 10) { //Note: this is just a placeholder. Above doesn't work
        //     ShowScorePanel();
        // }
    }

    public void ShowScorePanel() {
        ScorePanel.SetActive(true);
        PauseButton.SetActive(false);
        TextBox.SetActive(false);
        QuotaPanel.SetActive(false);
        GameObject.Find("Canvas").GetComponent<pauseScript>().enabled = false;
        Time.timeScale = 0f;
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
