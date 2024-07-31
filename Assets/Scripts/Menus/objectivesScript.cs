using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class objectivesScript : MonoBehaviour
{

    public static bool objectivesShown = true; //At the beginning of the level, the objectives should be shown
    public GameObject ObjectivesMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowObjectivesMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowObjectivesMenu()
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