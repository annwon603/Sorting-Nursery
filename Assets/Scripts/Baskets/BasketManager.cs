using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketManager : MonoBehaviour
{
    public List<GameObject> listOfBaskets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        foreach(var item in listOfBaskets)
        {
            item.GetComponent<BasketControl>().canShow = true;
        }

        // FindObjectOfType<BasketPage>()?.InitBasketInventoryUI();
        
    }
}
