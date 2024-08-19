using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketControl : MonoBehaviour
{
    [SerializeField]
    private BasketPage inventoryUI;
    public bool canShow = false;
    public int inventorySize;



    bool isDeleted = false;

    // Update is called once per frame
    void Update()
    {
        inventorySize = transform.parent.gameObject.GetComponent<BasketCap>().counter;
    }

    void OnMouseDown()
    {
        if(canShow){
            inventoryUI.InitBasketInventoryUI(inventorySize);
            inventoryUI.Show();
            StartCoroutine(Convert());
        }
    }

    IEnumerator Convert()
    {
        isDeleted = checkIfNull();
        yield return new WaitForSeconds(0.5f);
        yield return null;
        if(isDeleted == false){
            inventoryUI.UpdateItem(transform.parent.gameObject.GetComponent<BasketCap>().listOfEggs);
        }
    }

    //checks if everything in the list is Null
    private bool checkIfNull()
    {
        bool isNull = true;
        foreach(var item in transform.parent.gameObject.GetComponent<BasketCap>().listOfEggs)
        {
            //if it run into any non-null game object, break the loop and return false
            if(item != null)
            {
                isNull = false;
                break;
            } 
        }

        return isNull;
    }

    


}
