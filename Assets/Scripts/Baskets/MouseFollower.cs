using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private UIBasketItem item;

    [SerializeField]
    private LayerMask detectionLayer; // Layer to detect

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
        DetectHover();
        if (Input.GetMouseButtonUp(0)) // Detect left mouse button release
        {
            DetectMouseRelease();
        }
    }
    
    public void Toggle(bool val)
    {
        Debug.Log($"Item toggled {val}");
        gameObject.SetActive(val);
    }

    private void DetectHover()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, detectionLayer);

        if (hit.collider != null)
        {
            GameObject hoveredObject = hit.collider.gameObject;
            Debug.Log($"Hovered over: {hoveredObject.name}");
            transform.GetChild(0).GetComponent<CanvasGroup>().alpha = 0.9f;

        }

        StartCoroutine(ChangeBack());
    }
    IEnumerator ChangeBack()
    {
        yield return new WaitForSeconds(2.0f);
        transform.GetChild(0).GetComponent<CanvasGroup>().alpha = 0.50f;
    }

    private void DetectMouseRelease()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, detectionLayer);

        if (hit.collider != null)
        {
            GameObject releasedOverObject = hit.collider.gameObject;
            Debug.Log($"Mouse released over: {releasedOverObject.name}");

            // Handle the release event, e.g., dropping an item onto the game object
            OnMouseReleasedOverObject(releasedOverObject);
        }
        else
        {
            Debug.Log("Mouse released, but no object was detected.");
        }
    }

    private void OnMouseReleasedOverObject(GameObject releasedOverObject)
    {
        // Handle what happens when the mouse is released over a specific object
        // For example, you might drop an item onto it, trigger an event, etc.
        Debug.Log($"Handling release over: {releasedOverObject.name}");
        // Add your custom logic here
    }

    

}
