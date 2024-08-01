using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSetter : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; 
    public TextMeshProUGUI newText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnEnable()
    {
        textMeshPro.text = newText.text;
    }
}
