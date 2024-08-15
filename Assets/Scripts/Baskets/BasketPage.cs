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

    [SerializeField]
    private MouseFollower mouseFollower;

    public GameObject testEgg ,testEgg2;

    private int currentlyDraggedItemIndex = -1;


    //public UIBasketItem[] listOfBasketItems;
    private void Awake()
    {
        Hide();
        mouseFollower.Toggle(false);
    }


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
        Debug.Log(obj.eggPrefab.name);
        testEgg = obj.eggPrefab;
        testEgg2 = listOfBasketItems[1].eggPrefab;
        
    }

    private void HandleBeginDrag(UIBasketItem obj)
    {
        
        int index = listOfBasketItems.IndexOf(obj);
        if(index == -1)
        {
            return;
        }
        currentlyDraggedItemIndex = index;

        mouseFollower.Toggle(true);
        //testEgg = obj.eggPrefab;
        mouseFollower.SetData(index == 0 ? testEgg : testEgg2);
        //mouseFollower.SetData(testEgg);
    }

    private void HandleSwap(UIBasketItem obj)
    {
        int index = listOfBasketItems.IndexOf(obj);
        if (index == -1)
        {
            mouseFollower.Toggle(false);
            currentlyDraggedItemIndex = -1;
            return;
        }

        listOfBasketItems[currentlyDraggedItemIndex]
            .SetData(index == 0 ? testEgg : testEgg2);
        listOfBasketItems[index]
            .SetData(currentlyDraggedItemIndex == 0 ? testEgg : testEgg2);
        mouseFollower.Toggle(false);
        currentlyDraggedItemIndex = -1;
        Debug.Log("It swapped");
    }

    private void HandleEndDrag(UIBasketItem obj)
    {
        StartCoroutine(endDrag());
    }



    public void Show()
    {
        gameObject.SetActive(true);

//        listOfBasketItems[0].SetData(testEgg);

    }

    public void Hide()
    {
        gameObject.SetActive(false);
        ClearItem();
    }

    public void ClearList()
    {
        listOfBasketItems.Clear();
    }

    IEnumerator endDrag()
    {
        yield return new WaitForSeconds(1.0f);
        mouseFollower.Toggle(false);
    }
    
}
