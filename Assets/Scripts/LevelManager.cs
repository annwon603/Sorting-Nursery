using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   void Update()
   {

        if(FindObjectOfType<DialogueManager>().counter == 2)
        {
           Activate();
        }

        if(FindObjectOfType<DialogueManager>().counter == 5)
        {
           EggSpawn();
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

}
