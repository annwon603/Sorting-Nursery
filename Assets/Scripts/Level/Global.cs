using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    // Start is called before the first frame update

    public enum GameState {
        ShowObjective, 
        ShowDialogue,
        Gameplay,
        ShowQuota,
        Score,
    }

    public static GameState CurrentGameState = GameState.ShowObjective;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        CurrentGameState = GameState.Gameplay;
    }
}
