using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class pauseScript : MonoBehaviour {

    public static bool gamePaused = false;
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public DragChick[] AllChickens;
    public GameObject[] AllEggs;
    public DragDrop[] AllEggsInLevel;

    // Start is called before the first frame update
    void Start() 
    {
        Resume();
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gamePaused = true;
            if (gamePaused)
            {
                Pause();
            } else {
                Resume();
            }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
        gamePaused = false;

        foreach (DragChick chicken in AllChickens) {
            chicken.isPaused = false;
        }
        if (AllEggs == null) {
            AllEggs = GameObject.FindGameObjectsWithTag("Egg");
        }
        Debug.Log("Game is resumed");
        foreach (GameObject egg in AllEggs) {
            Debug.Log("Layer eggs");
            foreach (DragDrop eggInLevel in AllEggsInLevel) {
                Debug.Log("Eggs is not paused");
                eggInLevel.isPaused = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            gamePaused = true;
            if (gamePaused)
            {
                Pause();
            } else {
                Resume();
            }
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
        
        foreach (DragChick chicken in AllChickens)
        {
            chicken.isPaused = true;
        }
        if (AllEggs == null) {
            AllEggs = GameObject.FindGameObjectsWithTag("Egg");
        }
        foreach (GameObject egg in AllEggs) {
            foreach (DragDrop eggInLevel in AllEggsInLevel) {
                eggInLevel.isPaused = true;
            }
        }

        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
