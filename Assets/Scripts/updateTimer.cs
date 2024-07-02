using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateTimer : MonoBehaviour
{
    public Text TimeElapsed;
    private float timeCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        TimeElapsed.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        int secondsElapsed = Mathf.FloorToInt(timeCounter);
        TimeElapsed.text = secondsElapsed.ToString();
    }
}
