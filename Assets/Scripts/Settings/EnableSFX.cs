//Button click SFX got from https://pixabay.com/sound-effects/search/button-click/
//Source used: https://www.youtube.com/watch?v=HtiWt0SWxk8&ab_channel=xxRafaelProductions-RafaelVicuna
//https://pixabay.com/sound-effects/search/chicken/
//https://pixabay.com/sound-effects/search/cardboard/
//https://pixabay.com/sound-effects/search/gaming-chair/?pagi=3
//https://pixabay.com/sound-effects/search/point/

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
        }
        else {
            script.enabled = false;
        }
    }
}
