using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class showTimer : MonoBehaviour
{
    public Toggle isTimerOn;
    public GameObject TimerSetting;
    public GameObject TimeInfo;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(TimerSetting);
        if (!(isTimerOn.isOn)) {
            Debug.Log("Timer is off");
            TimeInfo.SetActive(false); 
        }
        if (isTimerOn.isOn) {
            Debug.Log("Time is on");
            TimeInfo.SetActive(true);
        }
    }
}

//Ask Annie on Thursday if I can have the isTimerOn and timerSetting to be prefabs so that all the scenes
//can use them