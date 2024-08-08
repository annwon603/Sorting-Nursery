using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseButton : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public DragChick[] AllChickens;
    public DragDrop[] AllEggs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPauseMenu()
    {
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0f;

        foreach (DragChick chicken in AllChickens) {
            chicken.isPaused = true;
        }
        foreach (DragDrop egg in AllEggs) {
            egg.isPaused = true;
        }
    }
}
