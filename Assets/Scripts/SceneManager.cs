using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    // Start is called before the first frame update

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }

    public void testing()
    {
        Debug.Log("You Click Me!");
    }
}
