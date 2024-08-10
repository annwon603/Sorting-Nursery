using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseButton : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public DragChick[] AllChickens;

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
        GameObject[] AllEggs = GameObject.FindGameObjectsWithTag("Egg");

        foreach (DragChick chicken in AllChickens) {
            chicken.isPaused = true;
        }
        if (AllEggs != null) {
            Debug.Log("Game is curr paused");
            
            // Loop through each egg and set isPaused to false
            foreach (GameObject egg in AllEggs) {
                DragDrop dragDrop = egg.GetComponent<DragDrop>();
                if (dragDrop != null) {
                    dragDrop.isPaused = true;  // Or true if the game is paused
                }
            }
        }
    }
}
