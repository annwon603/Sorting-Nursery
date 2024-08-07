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
        GetComponent<DragChick>().enabled = false;
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
