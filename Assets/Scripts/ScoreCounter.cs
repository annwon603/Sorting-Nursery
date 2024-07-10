using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI scoreText;
    private int scoreValue = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + scoreValue;
    }

    public void IncreaseScore()
    {
        scoreValue++;
    }
}
