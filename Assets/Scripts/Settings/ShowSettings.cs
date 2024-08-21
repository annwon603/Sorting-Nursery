using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSettings : MonoBehaviour
{

    public GameObject SettingsPanel;
    public GameObject CloseSettingsButton;

    // Start is called before the first frame update
    void Start()
    {
        SettingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSettingsPanel()
    {
        SettingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        SettingsPanel.SetActive(false);
    }
}
