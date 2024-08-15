using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Transform mCursorVisual;

    void Start()
    {
      // this sets the base cursor as invisible
      Cursor.visible = false;
    }

    void Update()
    {
        mCursorVisual.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Cursor.visible = false;

    }
}
