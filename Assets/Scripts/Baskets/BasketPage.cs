using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketPage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private UIBasketItem itemPrefab;
    [SerializeField]
    private RectTransform contentPanel;

    List<UIBasketItem> listOfBasketItems = new List<UIBasketItem>();

    public void Update()
    {
        
    }

    public void InitBasketInventoryUI(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            UIBasketItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
            uiItem.transform.SetParent(contentPanel);
            listOfBasketItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            
        }
    }

    private void HandleItemSelection(UIBasketItem obj)
    {
        Debug.Log(obj.name);
    }

    private void HandleBeginDrag(UIBasketItem obj)
    {

    }

    private void HandleSwap(UIBasketItem obj)
    {

    }

    private void HandleEndDrag(UIBasketItem obj)
    {

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
