using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VcaController : MonoBehaviour
{
    // Start is called before the first frame update
    private FMOD.Studio.VCA vcaController;

    [SerializeField]
    private string path;    // Ex: "vca:/Master:" without the Paretheseis

    public Toggle toggle;

    void Start()
    {
        vcaController = FMODUnity.RuntimeManager.GetVCA("vca:/" + path);
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    public void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            TurnOn();
            Debug.Log("Turn on");
        }
        else
        {
            TurnOff();
            Debug.Log("Turn off");
        }
    }

    // Update is called once per frame
    public void TurnOff()
    {
        vcaController.setVolume(0f);
    }

    public void TurnOn()
    {
        vcaController.setVolume(1f);
    }
}
