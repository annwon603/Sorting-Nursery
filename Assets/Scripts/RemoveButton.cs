using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button?.onClick.AddListener(() => RemoveObject());
    }

    // Update is called once per frame
    private void RemoveObject()
    {
        Debug.Log("Button B pressed");
    }
}
