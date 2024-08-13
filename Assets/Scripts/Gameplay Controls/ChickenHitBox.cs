using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenHitBox : MonoBehaviour
{
    public Transform target;  // Reference to the object you want to follow
    public Sprite oldSprite;
    public Sprite newSprite;

    bool doesChange = false;
    void Update()
    {
        if (target != null)
        {
            // Set the position of the current object to the target's position
            transform.position = target.position;
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Egg")
        {
            doesChange = GetComponent<Ran>().doesTurn; 
            if(doesChange == true)
            {
                StartCoroutine(SpriteChange());
            }
        }
    }

    IEnumerator SpriteChange()
    {
        transform.parent.GetComponent<SpriteRenderer>().sprite = newSprite;
        yield return new WaitForSeconds(0.5f);
        transform.parent.GetComponent<SpriteRenderer>().sprite = oldSprite;
        doesChange = false;
    }


}
