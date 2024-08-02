using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class resultsScript : MonoBehaviour
{
    public GameObject ResultsMenu;
    public GameObject ObjectivesPanel;
    public GameObject ShowObjectivesButton;
    public TMP_Text EggsSortedCorrect;
    public TMP_Text TotalEggs;
    public TMP_Text AccuracyNumber;

    // Start is called before the first frame update
    void Start()
    {
        ResultsMenu.SetActive(false);
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

    public void ShowResultsMenu() {
        ResultsMenu.SetActive(true);
        GameObject.Find("Canvas").GetComponent<pauseScript>().enabled = false;
        Time.timeScale = 0f;
        ObjectivesPanel.SetActive(false);
        ShowObjectivesButton.SetActive(false);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
