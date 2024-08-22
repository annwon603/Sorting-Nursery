using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroOrLevelSelect : MonoBehaviour
{

    public GameObject PlayButton;
    public GameObject LevelSelectButton;

    public int levelsComplete;

    // Start is called before the first frame update
    void Start()
    {
        levelsComplete = PlayGround.numOfDinos;

        if (levelsComplete == 0) {
            PlayButton.SetActive(true);
            LevelSelectButton.SetActive(false);
        }
        else {
            PlayButton.SetActive(false);
            LevelSelectButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
