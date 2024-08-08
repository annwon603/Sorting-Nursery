using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.EventSystems;

public class IncubatorSlot : MonoBehaviour
{
   private Collider2D z_Collider; //incubator's collider
   [SerializeField]
   private ContactFilter2D z_Filter; //contains a set of parameters for filtering contact results
   private List<Collider2D> z_CollidedObjects = new List<Collider2D>(1); //Should only have the egg in the list

   private Color originalColor;
   private Color hover; //Intereaction for player to see if egg is hover over the box

   private bool z_Intereacted = false; //Check if egg is over the incubator

   public Traits IncuTrait;


   private void Start()
   {
      z_Collider = GetComponent<Collider2D>();
      originalColor = GetComponent<SpriteRenderer>().color;
      hover = originalColor;
      hover.a = 0.9f;
   }
   

   private void Update()
   {
      z_CollidedObjects.Clear();
      z_Collider.OverlapCollider(z_Filter, z_CollidedObjects);
      if (z_CollidedObjects.Count > 0)
        {
            foreach (var o in z_CollidedObjects)
            {
               // OnCollided(o.gameObject);
               //Debug.Log("Collided");
            }
        }
        else
        {
            OnNotCollided();
        }
      
   }

   public void OnTriggerStay2D(Collider2D other)
   {
      if(other.gameObject.tag == "Egg"){
         OnInteract();
         DragDrop egg = other.gameObject.GetComponent<DragDrop>();
         bool doesMatch = traitMatch(egg.trait.isTraitActive, egg.trait.traitSet);
         if(Input.GetMouseButton(0) == false)
         {
            if(doesMatch == true){
               Debug.Log("In the right box");
               ScoreCounter.instance.IncreaseScore();
            }else{
               Debug.Log("In the wrong box");
            }

            other.gameObject.SetActive(false);
         
            Debug.Log("Egg in the box");

         }
         
      }
   }

   //For just comparing the Egg through UI
   public void Compare()
   {
      List<UIBasketItem> eggsToCompare = FindObjectOfType<BasketPage>().listOfBasketItems;
      Debug.Log("Found BasketUI");
      foreach(var egg in eggsToCompare)
      {
         bool doesMatch = traitMatch(egg.trait.isTraitActive, egg.trait.traitSet);
         if(doesMatch == true){
               Debug.Log("In the right box");
               ScoreCounter.instance.IncreaseScore();
            }else{
               Debug.Log("In the wrong box");
         }
         Destroy(egg.eggPrefab);
         egg.ResetData();
      }

      FindObjectOfType<BasketPage>().ClearItem();
      
   }

   public bool traitMatch(bool trait, string traitSet)
   {
      //First it checks if the boolean value "isTraitActive" of both incubator
      //and egg matches. Then it checks if both strings matches
      bool match = ((trait && IncuTrait.isTraitActive) || 
                     !(IncuTrait.isTraitActive || trait));
      return match && (traitSet == IncuTrait.traitSet);
   }

   private void OnNotCollided()
   {
      // Debug.Log("Not Collided");
      z_Intereacted = false;
      GetComponent<SpriteRenderer>().color = originalColor;
   }

   private void OnInteract()
   {
      // if z_interacted is false
      if(!z_Intereacted){
         z_Intereacted = true;
         Debug.Log("I'm at " + gameObject.name);
         GetComponent<SpriteRenderer>().color = hover;
      }
      
   }

   
}
