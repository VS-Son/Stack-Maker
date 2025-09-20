using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
   private void OnTriggerEnter(Collider col)
   {
      if (col.CompareTag("Player"))
      {
         col.GetComponent<Player>().OnWin();
         Debug.Log("Win");
      }
   }
}
