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
           
        }

        if(FindObjectOfType<DialogueManager>().counter == 6)
        {
            if(FindObjectOfType<BasketManager>().areAllFull)
           {
                // FindObjectOfType<DialogueManager>().showButton();
                GameObject.Find("Task").GetComponent<DialogueTrigger>().enabled = true;
                FindObjectOfType<BasketManager>().Activate();
           }
            // FindObjectOfType<DialogueManager>().showButton();
        }

        if(FindObjectOfType<BasketPage>() != null && FindObjectOfType<DialogueManager>().counter == 7)
        {
            FindObjectOfType<DialogueManager>().showButton();
        }

        if(FindObjectOfType<DialogueManager>().counter == 9 && GameObject.FindWithTag("Egg") == null)
        {
            FindObjectOfType<DialogueManager>().showButton();
        }

        if(FindObjectOfType<DialogueManager>().counter == 10)
        {
           scorePanel.SetActive(true);
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
        FindObjectOfType<BasketManager>().enabled = true;
    }

    

    


}
