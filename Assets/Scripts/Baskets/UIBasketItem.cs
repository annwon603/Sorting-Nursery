using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
public class UIBasketItem : MonoBehaviour
{
    [SerializeField]
    private Image itemImage;

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
        empty = true;
    }

    public void SetData(Sprite sprite, int quantity)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        empty = false;
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
        PointerEventData pointerData = (PointerEventData)data;
        if(pointerData.button == PointerEventData.InputButton.Left)
        {
            OnItemClicked?.Invoke(this);
        }


    }


}
