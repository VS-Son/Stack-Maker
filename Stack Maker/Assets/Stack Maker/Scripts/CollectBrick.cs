using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBrick : MonoBehaviour
{
   private Rigidbody m_Rigidbody;
   private void Start()
   {
      m_Rigidbody = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      
   }

   private void OnTriggerEnter(Collider hit)
   {
      if (hit.CompareTag($"Player"))
      {
         Player player = hit.GetComponent<Player>();
         if (player != null)
         {
            player.OnCollectionBrick();
         } 
         // Debug.Log("trigger" + hit.gameObject.name);
         gameObject.SetActive(false);

      }
   }
}
