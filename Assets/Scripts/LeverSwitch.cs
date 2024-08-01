using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite newSprite;
    public Sprite oldSprite;
    bool isSwitched = false;

    

    // Update is called once per frame
    void Start()
    {
        oldSprite = GetComponent<SpriteRenderer>().sprite;
    }

    void OnMouseDown()
    {
        Switch();
        Debug.Log("Got Switched");
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Move the egg if the switcdh got activated 
        if(other.CompareTag("Egg") && isSwitched == true && other.gameObject.GetComponent<Move>().changedNode)
        {
            other.GetComponent<Move>().doesTurn = true;
        }

        if(other.CompareTag("Egg") && isSwitched == false && other.gameObject.GetComponent<Move>().changedNode)
        {
            other.GetComponent<Move>().doesTurn = false;
        }
    }
}
