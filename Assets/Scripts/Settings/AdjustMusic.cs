//Menu music got from Annie
//Source used: https://www.youtube.com/watch?v=XE4ovK5o9tA&ab_channel=TheCryptoGym-AustinPatkos%28APex%29

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdjustSounds : MonoBehaviour
{

    public Slider volumeSlider;
    public static float menusMusicLevel = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = menusMusicLevel;
        UpdateMusicLevels();
    }

    // Update is called once per frame
    void Update()
    {
        menusMusicLevel = volumeSlider.value;
        UpdateMusicLevels();
    }

    void UpdateMusicLevels()
    {
        Debug.Log("Volume is " + menusMusicLevel);
    }
}
