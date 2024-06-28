using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.EventSystems;

public class IncubatorSlot : MonoBehaviour
{
   private Collider2D z_Collider;
   [SerializeField]
   private ContactFilter2D z_Filter;
   private List<Collider2D> z_CollidedObjects = new List<Collider2D>(1);

   private Color originalColor;
   private Color hover; //Intereaction for player to see if egg is hover over the box

   private bool z_Intereacted = false;
   private void Start()
   {
      z_Collider = GetComponent<Collider2D>();
      originalColor = GetComponent<SpriteRenderer>().color;
      hover = originalColor;
      hover.a = 0.9f;
   }

   private void Update()
   {
      z_Collider.OverlapCollider(z_Filter, z_CollidedObjects);
      foreach(var o in z_CollidedObjects)
      {
         OnCollided(o.gameObject);
      }
   }

   private void OnCollided(GameObject collidedObject)
   {
      // Debug.Log("Collided with " + collidedObject.name);
      if(Input.GetMouseButton(0))
      {
         OnInteract();
      }
   }

   private void OnInteract()
   {
      // if z_interacted is false
      if(!z_Intereacted){
         z_Intereacted = true;
         Debug.Log("Left button being held down");
      }else{
         
      }
      
   }



   // public void OnDrop(PointerEventData eventData){

   //  Debug.Log("OnDrop");
   // }
}
