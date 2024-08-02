using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public GameObject scorePanel;
  
   void Update()
   {

        if(FindObjectOfType<DialogueManager>().counter == 2)
        {
            Destroy(GameObject.Find("EggShellBG"));
           Activate();
        }

        if(FindObjectOfType<DialogueManager>().counter == 5)
        {
           EggSpawn();
           if(FindObjectOfType<EggManager>().areAllSpawn)
           {
                FindObjectOfType<DialogueManager>().showButton();
                FindObjectOfType<BasketManager>().Activate();
           }
        }

        if(FindObjectOfType<BasketPage>() != null && FindObjectOfType<DialogueManager>().counter == 6)
        {
            FindObjectOfType<DialogueManager>().showButton();
        }

        if(FindObjectOfType<DialogueManager>().counter == 8 && GameObject.FindWithTag("Egg") == null)
        {
            FindObjectOfType<DialogueManager>().showButton();
        }

        if(FindObjectOfType<DialogueManager>().counter == 9)
        {
        //    AppendAlphaToExistingText(1.0f);
        //    scorePanel.SetActive(true);

        }




   }

    private void Activate() 
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject.tag == "TutorialTask1")
            {
                transform.GetChild(i).gameObject.SetActive(true);
                Debug.Log(transform.GetChild(i).gameObject.name + " got activated");
            }
        }
    }

    private void EggSpawn()
    {
        FindObjectOfType<EggManager>().enabled = true;
    }

    void AppendAlphaToExistingText(float alpha)
    {
        // Retrieve the existing text
        string existingText = textMeshProUGUI.text;

        // Define the color (e.g., white)
        Color color = Color.white;
        color.a = alpha; // Set the desired alpha value

        // Convert the color to a hex string
        string colorHex = ColorUtility.ToHtmlStringRGBA(color);

        // Append new text with the color tag and alpha
        // Ensure you append this in a way that maintains existing text formatting
        string newText = $"<color=#{colorHex}>{existingText}</color>";

        // Set the updated text back to TextMeshProUGUI
        textMeshProUGUI.text = newText;
    }


}
