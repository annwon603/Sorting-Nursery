using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private UIBasketItem item;

    public void Awake()
    {
        canvas = transform.root.GetComponent<Canvas>();
        mainCamera = Camera.main;
        item = GetComponentInChildren<UIBasketItem>();
        item.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void SetData(GameObject egg)
    {
        item.SetData(egg);
    }
    void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            Input.mousePosition,
            canvas.worldCamera,
            out position
                );
        transform.position = canvas.transform.TransformPoint(position);
    }
    
    public void Toggle(bool val)
    {
        Debug.Log($"Item toggled {val}");
        gameObject.SetActive(val);
    }
}
