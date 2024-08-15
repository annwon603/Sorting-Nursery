using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LeverSwitchSprite : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite newSprite;
    public Sprite oldSprite;
    public bool isSwitched = false;
    void Start()
    {
        oldSprite = GetComponent<SpriteRenderer>().sprite;
    }

    void OnMouseDown()
    {
        Switch();
    }

    public void Switch()
    {
        if(!isSwitched)
        {
            GetComponent<SpriteRenderer>().sprite = newSprite;
            isSwitched = true;
        }else{
            GetComponent<SpriteRenderer>().sprite = oldSprite;
            isSwitched = false;
        }
    }

}
