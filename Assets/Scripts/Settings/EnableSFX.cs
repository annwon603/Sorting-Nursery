//Button click SFX got from https://pixabay.com/sound-effects/search/button-click/
//Source used: https://www.youtube.com/watch?v=HtiWt0SWxk8&ab_channel=xxRafaelProductions-RafaelVicuna

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnableSFX : MonoBehaviour
{

    public Toggle isSFXOn;
    public static bool SFXOn = true; //By default, the SFX should be on
    FMODUnity.StudioEventEmitter script;

    // Start is called before the first frame update
    void Start()
    {
        isSFXOn.isOn = SFXOn;
        script = GetComponent<FMODUnity.StudioEventEmitter>();
        UpdateSFXSounds();
    }

    // Update is called once per frame
    void Update()
    {
        SFXOn = isSFXOn.isOn;
        UpdateSFXSounds();
    }

    public void UpdateSFXSounds()
    {
        if (SFXOn) {
            script.enabled = true;
            Debug.Log("SFX is on ");
        }
        else {
            script.enabled = false;
            Debug.Log("SFX is off");
        }
    }
}
