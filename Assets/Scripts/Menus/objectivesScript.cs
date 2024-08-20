using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class objectivesScript : MonoBehaviour
{
    public GameObject ObjectivesMenu;
    public GameObject PauseButton;
    public DragChick[] AllChickens;
    public GameObject TextBox;
    public GameObject QuotaPanel;

    // Start is called before the first frame update
    void Start()
    {
        ObjectivesMenu.SetActive(true);
        PauseButton.SetActive(false);
        GameObject.Find("Canvas").GetComponent<pauseScript>().enabled = false;
        //GameObject[] AllEggs = GameObject.FindGameObjectsWithTag("Egg");

        foreach (DragChick chicken in AllChickens) {
            chicken.isPaused = true;
        }
        // if (AllEggs == null) {
        //     AllEggs = GameObject.FindGameObjectsWithTag("Egg");
        // }
        // foreach (GameObject egg in AllEggs) {
        //     foreach (DragDrop eggInLevel in AllEggsInLevel) {
        //         eggInLevel.isPaused = true;
        //     }
        // }

        // if (AllEggs != null) {
        //     Debug.Log("Game is curr paused");
            
        //     // Loop through each egg and set isPaused to false
        //     foreach (GameObject egg in AllEggs) {
        //         DragDrop dragDrop = egg.GetComponent<DragDrop>();
        //         if (dragDrop != null) {
        //             dragDrop.isPaused = true;  // Or true if the game is paused
        //         }
        //     }
        // }
        ShowObjectivesMenu();
        Global.CurrentGameState = Global.GameState.ShowObjective;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowObjectivesMenu()
    {
        ObjectivesMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Play() 
    {
        Time.timeScale = 1f;
        GameObject.Find("Canvas").GetComponent<pauseScript>().enabled = true;
        PauseButton.SetActive(true);
        TextBox.SetActive(true);
        QuotaPanel.SetActive(true);
        GameObject[] AllEggs = GameObject.FindGameObjectsWithTag("Egg");

        foreach (DragChick chicken in AllChickens) {
            chicken.isPaused = false;
        }
        if (AllEggs != null) {
            Debug.Log("Game is resumed");
            
            // Loop through each egg and set isPaused to false
            foreach (GameObject egg in AllEggs) {
                DragDrop dragDrop = egg.GetComponent<DragDrop>();
                if (dragDrop != null) {
                    dragDrop.isPaused = false;  // Or true if the game is paused
                }
            }
        }

        ObjectivesMenu.SetActive(false);
    }

    public void ShowObjectivesPanel()
    {
        ObjectivesMenu.SetActive(false);
    }

    public void CloseObjectivesPanel()
    {
        ObjectivesMenu.SetActive(false);
        GameObject.Find("Canvas").GetComponent<pauseScript>().enabled = true;
        //PauseButton.SetActive(true);
    }
}