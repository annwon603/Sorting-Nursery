using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [SerializeField]
    public MouseFollower mouseFollower;

    public GameObject testEgg ,testEgg2;

    private int currentlyDraggedItemIndex = -1;

    public bool isDisplay = false;


    //public UIBasketItem[] listOfBasketItems;
    private void Awake()
    {
        Hide();
        mouseFollower.Toggle(false);
    }


    public void FixedUpdate()
    {
        // foreach(var item in listOfBasketItems)
        // {
        //     item.transform.GetChild(0).gameObject.SetActive(true);
        // }   
        if(isDisplay)
        {
            StartCoroutine(checkForMissingEggs());
        }
    }

    //Updates the BasketUI if the player dragged the egg to the incubator 
    IEnumerator checkForMissingEggs()
    {
        yield return new WaitForSeconds(1.0f);
        for (int i = listOfBasketItems.Count - 1; i >= 0; i--)
        {
            if (listOfBasketItems[i].eggPrefab == null)
            {
                listOfBasketItems.RemoveAt(i);
                if (i < contentPanel.childCount)
                {
                    Transform child = contentPanel.GetChild(i);
                    Destroy(child.gameObject);
                }
            }
        }

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
        Debug.Log(obj.eggPrefab.name);
        
    }

    private void HandleBeginDrag(UIBasketItem obj)
    {
        
        int index = listOfBasketItems.IndexOf(obj);
        if(index == -1)
        {
            return;
        }
        currentlyDraggedItemIndex = index;
        Debug.Log(obj.eggPrefab.name);
        testEgg = obj.eggPrefab;

        mouseFollower.Toggle(true);
        //testEgg = obj.eggPrefab;
        //mouseFollower.SetData(index == 0 ? testEgg : testEgg2);
        mouseFollower.SetData(testEgg);
    }

    private void HandleSwap(UIBasketItem obj)
    {

    }

    private void HandleEndDrag(UIBasketItem obj)
    {
        StartCoroutine(endDrag());
    }

    IEnumerator endDrag()
    {
        yield return new WaitForSeconds(0.2f);
        mouseFollower.Toggle(false);
    }

    public void OnItemDroppedOn()
    {
        for (int i = listOfBasketItems.Count - 1; i >= 0; i--)
        {
            if (listOfBasketItems[i].eggPrefab == null)
            {
                listOfBasketItems.RemoveAt(i); 
                Debug.Log("Updated Basket Page");
            }
        }
    }


    public void Show()
    {
        gameObject.SetActive(true);
        isDisplay = true;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        isDisplay = false;
        ClearItem();
    }

    public void ClearList()
    {
        listOfBasketItems.Clear();
    }

    
    
    
}
