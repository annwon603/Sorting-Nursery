using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketManager : MonoBehaviour
{
    public List<GameObject> listOfBaskets;
    public EggManager eggManager;


    int totalBasketTotal;

    int currBasketcount = 0;

    [SerializeField]
    public bool areAllFull = false;
    // Start is called before the first frame update
    void Start()
    {
        totalBasketTotal = eggManager.Eggs.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(areAllFull == false)
        {
            foreach(var item in listOfBaskets)
            {
                currBasketcount += item.GetComponent<BasketCap>().counter;
            }

            if(currBasketcount == totalBasketTotal){
                areAllFull = true;
                Debug.Log(listOfBaskets.Count +" baskets are full");
            }else{
                currBasketcount = 0;
                //Debug.Log("Reseted currBasketCount");
            }
       }
    }

    public void Activate()
    {
        foreach(var item in listOfBaskets)
        {
            item.transform.GetChild(0).gameObject.GetComponent<BasketControl>().canShow = true;
        }
        // FindObjectOfType<BasketPage>()?.InitBasketInventoryUI();
    }
}
