//Menu music got from Annie
//Source used: https://www.youtube.com/watch?v=XE4ovK5o9tA&ab_channel=TheCryptoGym-AustinPatkos%28APex%29

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdjustSounds : MonoBehaviour
{

    public Toggle isMusicOn;
    public static bool MusicOn = true; //By default, the SFX should be on
    private FMODUnity.StudioEventEmitter musicObject;

    // Start is called before the first frame update
    void Start()
    {
        isMusicOn.isOn = MusicOn;
        musicObject = GetComponent<FMODUnity.StudioEventEmitter>();
        //musicObject = FMODUnity.StudioEventEmitter.getEvent("event:/Music/Background Music");
        //DontDestroyOnLoad(GameObject.Find("FMODUnity.StudioEventEmitter"));
        DontDestroyOnLoad(GameObject.Find())
        UpdateMusicSounds();
    }

    // Update is called once per frame
    void Update()
    {
        MusicOn = isMusicOn.isOn;
        UpdateMusicSounds();
    }

    void UpdateMusicSounds()
    {
        Debug.Log("MUSIC " +MusicOn);
        if (MusicOn) {
            musicObject.enabled = true;
        }
        else {
            musicObject.enabled = false;
        }
    }
}
