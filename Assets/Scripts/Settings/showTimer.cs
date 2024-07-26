using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class showTimer : MonoBehaviour
{
    public Toggle isTimerOn;
    public GameObject TimeInfo;
    public static bool timerVisible = false; // By default, the timer is not visible
    // public TMP_Text TimeElapsed;
    // private float timeCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        isTimerOn.isOn = timerVisible;
        UpdateTimerVisibility();
    }

    // Update is called once per frame
    void Update()
    {
        timerVisible = isTimerOn.isOn;
        UpdateTimerVisibility();
    }

    //Determines if the timer is visible or not and saves the data when switching scenes
    void UpdateTimerVisibility()
    {
        if (timerVisible) {
            TimeInfo.SetActive(true);
        }
        else {
            //Timer still needs to be ongoing even if it is not physcially visible, so set the size of the timer text to 0
            GameObject.Find("TimeInfo").transform.localScale = new Vector3(0, 0, 0);
            //Source: https://discussions.unity.com/t/how-can-i-hide-a-gameobject-without-active-false/64919
        }
    }
}