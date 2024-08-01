using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketControl : MonoBehaviour
{
    [SerializeField]
    private BasketPage inventoryUI;
    public bool canShow = false;
    public int inventorySize;
    // Start is called before the first frame update
    void Start()
    {
        inventorySize = transform.parent.gameObject.GetComponent<BasketCap>().eggCapacity;
        //inventoryUI.InitBasketInventoryUI();
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
        GameObject[] eggList = transform.parent.gameObject.GetComponent<BasketCap>().getEggList();
        inventoryUI.UpdateItem(eggList);
    }

}
