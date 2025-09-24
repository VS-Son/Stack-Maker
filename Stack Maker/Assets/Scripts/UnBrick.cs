using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnBrick : MonoBehaviour
{
   [SerializeField] private GameObject yellow;
     private void OnTriggerEnter(Collider col)
       {
           if (col.CompareTag("Player"))
           {
               if (yellow.activeSelf) return;
               Debug.Log(col.gameObject.name);
               yellow.SetActive(true);
               col.GetComponent<Player>().UnCollectionBrick();
           }
       }
}
