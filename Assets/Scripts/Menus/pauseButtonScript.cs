using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseButton : MonoBehaviour
{
    public GameObject PauseMenu;

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
        Time.timeScale = 0f;
    }
}
