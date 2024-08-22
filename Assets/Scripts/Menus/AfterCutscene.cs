using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterCutscene : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playButtonNoCutScene;
    void Start()
    {
        if(AfterOneCutScene.haveCutScenePlay == true)
        {
            playButton.SetActive(false);
            playButtonNoCutScene.SetActive(true);
        }
    }
}
