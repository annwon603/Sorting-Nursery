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

    [SerializeField]
    public List<UIBasketItem> listOfBasketItems = new List<UIBasketItem>();



    //public UIBasketItem[] listOfBasketItems;


    public void Update()
    {
        // foreach(var item in listOfBasketItems)
        // {
        //     item.transform.GetChild(0).gameObject.SetActive(true);
        // }
    }

    public void InitBasketInventoryUI(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            UIBasketItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
            uiItem.transform.SetParent(contentPanel, false);
            listOfBasketItems.Add(uiItem);
            // listOfBasketItems[i] = uiItem;
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            
        }
    }

    public void UpdateItem(List<GameObject> listofEggs)
    {
        for(int i = 0; i < listofEggs.Count; i++)
        {
            listOfBasketItems[i].SetData(listofEggs[i]);
        }
        // for (int i = 0; i < 5; i++)
        // {
        //     listOfBasketItems[i].SetData(eggs[i].GetComponent<SpriteRenderer>().sprite , eggs[i].GetComponent<DragDrop>().trait);
        // }
    }

    public void ClearItem()
    {
        foreach(var item in listOfBasketItems)
        {
            item.ResetData();
        }

        listOfBasketItems.Clear();
        
        foreach (Transform child in contentPanel)
        {
             Destroy(child.gameObject); // Destroy each child GameObject
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
        ClearItem();
    }
}
