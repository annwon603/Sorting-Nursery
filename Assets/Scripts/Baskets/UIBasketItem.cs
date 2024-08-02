using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
public class UIBasketItem : MonoBehaviour
{
    [SerializeField]
    public Image itemImage;
    public Traits trait; 

    public GameObject eggPrefab; //directly refer to the actual egg in basket

    public event Action<UIBasketItem> OnItemClicked, OnItemBeginDrag, OnItemEndDrag, 
                                        OnItemDroppedOn;

    private bool empty = true;

    public void Awake()
    {
        ResetData();
        
    }

    public void ResetData()
    {
        this.itemImage.gameObject.SetActive(false);
        this.itemImage.sprite = null;
        // Destroy(eggPrefab);
        this.eggPrefab = null;
        empty = true;
        Debug.Log("I got reseted");
    }

    public void SetData(GameObject egg)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = egg.GetComponent<SpriteRenderer>().sprite;
        this.trait = egg.GetComponent<DragDrop>().trait;
        this.eggPrefab = egg;
        empty = false;
        Debug.Log("I got Seted");
    }

    // ?. syntax means checking if it's not null
    public void OnBeginDrag()
    {
        if(empty)
            return;
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnDrop()
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnEndDrag()
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnPointerClick(BaseEventData data)
    {
        if(empty)
            return;
        PointerEventData pointerData = (PointerEventData)data;
        if(pointerData.button == PointerEventData.InputButton.Left)
        {
            OnItemClicked?.Invoke(this);
        }


    }


}
