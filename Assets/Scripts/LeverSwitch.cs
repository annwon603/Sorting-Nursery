using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite newSprite;

    bool isSwitched = false;

    // Update is called once per frame
    public void Switch()
    {
        GetComponent<SpriteRenderer>().sprite = newSprite;
        isSwitched = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Move the egg if the switcdh got activated 
        if(other.CompareTag("Egg") && isSwitched == true && other.gameObject.GetComponent<Move>().changedNode)
        {
            other.GetComponent<Move>().doesTurn = true;
        }
    }
}
