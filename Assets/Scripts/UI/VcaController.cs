using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VcaController : MonoBehaviour
{
    // Start is called before the first frame update
    private FMOD.Studio.VCA vcaController;
    private string path;    // Ex: "vca:/Master:" without the Paretheseis

    void Start()
    {
        vcaController = FMODUnity.RuntimeManager.GetVCA("vca:/" + path);
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
