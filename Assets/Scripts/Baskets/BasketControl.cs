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

    // Start is called before the first frame update
    void Start()
    {
        inventorySize = transform.parent.gameObject.GetComponent<BasketCap>().eggCapacity;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(canShow){
            inventoryUI.Show();
            inventoryUI.InitBasketInventoryUI(inventorySize);
            Convert();  
        }
    }

    void Convert()
    {
        isDeleted = checkIfNull();
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
