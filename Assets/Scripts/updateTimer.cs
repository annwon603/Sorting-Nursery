using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class updateTimer : MonoBehaviour
{
    public TMP_Text TimeElapsed;
    public TMP_Text SecondsText;
    public TMP_Text TimeText;
    private float timeCounter = 0f;
    public Toggle Toogle; 

    // Start is called before the first frame update
    void Start()
    {
        TimeElapsed.text = "0";
        Toogle.isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        int secondsElapsed = Mathf.FloorToInt(timeCounter);
        TimeElapsed.text = secondsElapsed.ToString();

        RectTransform rectTransform = SecondsText.GetComponent<RectTransform>();

        if (secondsElapsed >= 100)
        {
            rectTransform.anchoredPosition = new Vector2(370, rectTransform.anchoredPosition.y);
        }

        else if (secondsElapsed >= 10)
        {
            rectTransform.anchoredPosition = new Vector2(350, rectTransform.anchoredPosition.y);
        }

        // if (Toogle.isOn == true) {
        //     Toogle.onClick() = false;
        //     Debug.Log("Checkbox is on");
        //     // TimeElapsed.a = 0.0f;
        //     // SecondsText.a = 0.0f;
        //     // TimeText.a = 0.0f;
        // }

        // if (Toogle.isOn == false) {
        //     Toogle.onClick() = true;
        //     Debug.Log("Checkbox is off");
        //     // TimeElapsed.a = 0.0f;
        //     // SecondsText.a = 0.0f;
        //     // TimeText.a = 0.0f;
        // }
    }
}
