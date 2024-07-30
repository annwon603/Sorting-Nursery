using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class objectivesScript : MonoBehaviour
{

    public static bool objectivesShown = true; //At the beginning of the level, the objectives should be shown
    public GameObject ObjectivesMenu;
    public GameObject BeginLevelButton;
    public GameObject ResumeLevelButton;
    public TMP_Text TimeElapsed;
    //public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        int secondsElapsed = TimeElapsed.ToInt();
        if (secondsElapsed == 0 && objectivesShown == true) {
            BeginLevelButton.SetActive(true);
            ResumeLevelButton.SetActive(false);
        }
        if (secondsElapsed != 0 && objectivesShown == true) {
            BeginLevelButton.SetActive(false);
            ResumeLevelButton.SetActive(true);
        }
    }

    public void Resume()
    {
        ObjectivesMenu.SetActive(true);
        Time.timeScale = 0f;
        objectivesShown = true;
    }

    public void Play()
    {
        Time.timeScale = 1f;
        ObjectivesMenu.SetActive(false);
    }
}