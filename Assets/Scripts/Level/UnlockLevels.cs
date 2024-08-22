using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevels : MonoBehaviour
{
    //public static int numLevelsComplete = 0;
    public Button Level2Btn;
    public Button Level3Btn;

    public int levelsComplete;

    //Reference how many mandatory objectives have been completed

    // Start is called before the first frame update
    void Start()
    {
        levelsComplete = PlayGround.numOfDinos;
        
        if (levelsComplete == 1) {
            Level2Btn.GetComponent<Button>().interactable = true;
        }
        if (levelsComplete == 2) {
            Level2Btn.GetComponent<Button>().interactable = true;
            Level3Btn.GetComponent<Button>().interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
