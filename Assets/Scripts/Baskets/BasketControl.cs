using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketControl : MonoBehaviour
{
    [SerializeField]
    private BasketPage inventoryUI;

    public int inventorySize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        inventorySize = transform.parent.gameObject.GetComponent<BasketCap>().counter;
        inventoryUI.InitBasketInventoryUI(inventorySize);
        inventoryUI.Show();
        

    }
}
