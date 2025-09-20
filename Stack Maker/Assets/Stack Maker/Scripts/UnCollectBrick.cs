using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnCollectBrick : MonoBehaviour
{
   [SerializeField] private GameObject brick;
   private void OnTriggerEnter(Collider col)
   {
      if (col.CompareTag("Player"))
      {
         col.GetComponent<Player>().UnCollectionBrick();
         brick.SetActive(true);
      }
   }
}
