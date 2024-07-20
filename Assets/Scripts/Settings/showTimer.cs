// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class showTimer : MonoBehaviour
// {
//     public Toggle isTimerOn;
//     public GameObject TimeInfo;

//     // Start is called before the first frame update
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // DontDestroyOnLoad(isTimerOn);
//         if (!(isTimerOn.isOn)) {
//             Debug.Log("Timer is off");
//             TimeInfo.SetActive(false); 
//         }
//         if (isTimerOn.isOn) {
//             Debug.Log("Time is on");
//             TimeInfo.SetActive(true);
//         }
//     }
// }

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class showTimer : MonoBehaviour
// {
//     public Toggle isTimerOn;
//     public GameObject TimeInfo;
//     public static bool timerState = false; // Default value

//     // Start is called before the first frame update
//     void Start()
//     {
//         if (isTimerOn != null)
//         {
//             isTimerOn.isOn = timerState; // Set the toggle to the saved state
//         }

//         UpdateTimerVisibility();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (isTimerOn != null)
//         {
//             timerState = isTimerOn.isOn; // Save the state of the toggle
//             UpdateTimerVisibility();
//         }
//     }

//     void UpdateTimerVisibility()
//     {
//         if (TimeInfo != null)
//         {
//             TimeInfo.SetActive(timerState);
//             Debug.Log(timerState ? "Timer is on" : "Timer is off");
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class showTimer : MonoBehaviour
{
    public Toggle isTimerOn;
    public GameObject TimeInfo;
    public static bool timerVisible = false; // By default, the timer is not visible

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
            TimeInfo.SetActive(false);
        }
    }
}