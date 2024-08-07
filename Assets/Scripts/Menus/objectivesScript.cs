using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class objectivesScript : MonoBehaviour
{
    public GameObject ObjectivesMenu;
    public GameObject ObjectivesPanel;
    public GameObject ShowObjectivesButton;
    public GameObject PauseButton;
    Script dragChickenScript;

    // Start is called before the first frame update
    void Start()
    {
        ObjectivesMenu.SetActive(true);
        ObjectivesPanel.SetActive(false);
        ShowObjectivesButton.SetActive(false);
        PauseButton.SetActive(false);
        GameObject.Find("Canvas").GetComponent<pauseScript>().enabled = false;
        dragChickenScript = GetComponent<DragChick>();
        dragChickenScript.enabled = false;
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
    }

    public void Play()
    {
        Time.timeScale = 1f;
        GameObject.Find("Canvas").GetComponent<pauseScript>().enabled = true;
        GetComponent<DragChick>().enabled = true;
        PauseButton.SetActive(true);
        ObjectivesMenu.SetActive(false);
        ShowObjectivesButton.SetActive(true);
    }

    public void ShowObjectivesPanel()
    {
        ShowObjectivesButton.SetActive(false);
        ObjectivesPanel.SetActive(true);
        ObjectivesMenu.SetActive(false);
    }

    public void CloseObjectivesPanel()
    {
        ObjectivesPanel.SetActive(false);
        ShowObjectivesButton.SetActive(true);
    }
}