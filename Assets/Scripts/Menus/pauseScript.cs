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
        GameObject[] AllEggs = GameObject.FindGameObjectsWithTag("Egg");

        foreach (DragChick chicken in AllChickens) {
            chicken.isPaused = false;
        }
        if (AllEggs != null && Global.CurrentGameState == Global.GameState.Gameplay) {
            Debug.Log("Game is curr paused");
            
            // Loop through each egg and set isPaused to false
            foreach (GameObject egg in AllEggs) {
                DragDrop dragDrop = egg.GetComponent<DragDrop>();
                if (dragDrop != null) {
                    dragDrop.isPaused = false;  // Or true if the game is paused
                }
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
        GameObject[] AllEggs = GameObject.FindGameObjectsWithTag("Egg");
        
        foreach (DragChick chicken in AllChickens)
        {
            chicken.isPaused = true;
        }
        if (AllEggs != null) {
            Debug.Log("Game is resumed");
            
            // Loop through each egg and set isPaused to false
            foreach (GameObject egg in AllEggs) {
                DragDrop dragDrop = egg.GetComponent<DragDrop>();
                if (dragDrop != null) {
                    dragDrop.isPaused = true;  // Or true if the game is paused
                }
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

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
