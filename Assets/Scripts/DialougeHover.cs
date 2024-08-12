using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DialougeHover : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{

   //private bool mouse_over = false;
   public bool canDisappear = false;

   private CanvasGroup canvasGroup;
   void Awake()
   {
        canvasGroup = GetComponent<CanvasGroup>();
   }

    // void Update()
    // {
    //     if (mouse_over)
    //     {
    //         Debug.Log("Mouse Over");
    //     }
    // }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(canDisappear == true)
        {
            canvasGroup.alpha = 0f;
            Debug.Log("Mouse enter");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // transform.GetChild(0).gameObject.SetActive(true);
        canvasGroup.alpha = 1f;
        Debug.Log("Mouse exit");
        // mouse_over = false;
    }
}
