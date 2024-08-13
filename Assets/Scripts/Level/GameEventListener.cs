using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameEventListener : MonoBehaviour
{
   public GameEvent gameEvent;

   public UnityEvent Response; 

   private void OnEnable()
   {
        gameEvent.RegisterListener(this);
   }

   private void OnDisable()
   {
        gameEvent.UnregisterListener(this);
   }

    //This will be called by the gameEvent when it's broadcasted
   public void OnEventRaised()
   {
        Response.Invoke();
   }
}
