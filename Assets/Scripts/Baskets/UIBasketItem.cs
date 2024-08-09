using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
public class UIBasketItem : MonoBehaviour
{
    [SerializeField]


    public Image itemImage;
    public Traits trait; 

    public Vector3 scale; //Determine the size of the egg in Basket UI display

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
        this.trait = null;
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
        this.scale = determineScale(egg);
        transform.GetChild(0).localScale = scale;
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

    public Vector3 determineScale(GameObject egg)
    {
        Vector3 small = new Vector3(0.6f,0.6f,0.6f);
        Vector3 med = new Vector3(0.7f,0.7f,0.7f);
        Vector3 big = new Vector3(0.9f,0.9f,0.9f);
        Vector3 xlarge = new Vector3(1.1f,1.1f,1.1f);
        if(egg.GetComponent<DragDrop>().size.name == "Small")
        {
            return small;
        } else if(egg.GetComponent<DragDrop>().size.name == "Med")
        {
            return med;
        } else if(egg.GetComponent<DragDrop>().size.name == "Big")
        {
            return big;
        }else
        {
            return xlarge;
        }
        
    }


}
