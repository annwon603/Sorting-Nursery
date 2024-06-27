using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    // Start is called before the first frame update

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
