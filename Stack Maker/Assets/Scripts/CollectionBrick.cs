using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionBrick : MonoBehaviour
{

   private void OnTriggerEnter(Collider col)
   {
      if (col.CompareTag("Player"))
      {
         Debug.Log(col.gameObject.name);
         gameObject.SetActive(false);
         col.GetComponent<Player>().OnCollectionBrick();
      }
   }
}
