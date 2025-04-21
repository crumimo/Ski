using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         PLayerEvents.CallOnHitEvent();
         PlayerDetection();
      }
   }

   protected virtual void PlayerDetection()
   {
      Debug.Log("Player collided with: " +name);
   }
}
