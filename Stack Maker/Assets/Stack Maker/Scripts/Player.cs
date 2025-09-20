using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
   [SerializeField] private float speed = 5f;
   [SerializeField] private LayerMask layerMask;
   [SerializeField] private Transform collect;
   [SerializeField] private GameObject brickPrefab;
   [SerializeField] private Transform player;
   [SerializeField] private Transform finishLine;
   [SerializeField] private float distanceRayCast;

   private Rigidbody m_Rb;
   private Vector3 _moveDirection;

   private bool _isMoving;
   private bool _canMoveForward;
   private bool _canMoveBack;
   private bool _canMoveRight;
   private bool _canMoveLeft;

   private List<GameObject> m_ListCollectedBrick = new List<GameObject>();




   private void Start()
   {
      m_Rb = GetComponent<Rigidbody>();
   }

   private void OnEnable()
   {
      PlayerDrag.OnMove += OnMove;
   }

   private void OnDisable()
   {
      PlayerDrag.OnMove -= OnMove;
   }

   private void OnMove(Vector3 delta)
   {
      if (_isMoving) return;
      if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
      {
         if (delta.x > 0 && _canMoveRight)
         {
            _moveDirection = Vector3.right;
            _isMoving = true;
         }

         if (delta.x < 0 && _canMoveLeft)
         {
            _moveDirection = Vector3.left;
            _isMoving = true;
         }
      }
      else
      {
         if (delta.y > 0 && _canMoveForward)
         {
            _moveDirection = Vector3.forward;
            _isMoving = true;
         }

         if (delta.y < 0 && _canMoveBack)
         {
            _moveDirection = Vector3.back;
            _isMoving = true;
         }
      }
   }

   private void Update()
   {
      CheckDirectionAround();
   }

   private void FixedUpdate()
   {
      if (_moveDirection != Vector3.zero)
      {
         if (_moveDirection == Vector3.forward && !_canMoveForward)
         {
            _isMoving = false;
            _moveDirection = Vector3.zero;
            return;
         }
         if (_moveDirection == Vector3.back && !_canMoveBack)
         {
            _isMoving = false;
            _moveDirection = Vector3.zero;
            return;
         }
         if (_moveDirection == Vector3.left && !_canMoveLeft)
         {
            _isMoving = false;
            _moveDirection = Vector3.zero;
            return;
         }
         if (_moveDirection == Vector3.right && !_canMoveRight)
         {
            _isMoving = false;
            _moveDirection = Vector3.zero;
            return;
         }
         m_Rb.MovePosition(m_Rb.position + _moveDirection * speed * Time.fixedDeltaTime);
      }
   }

   private bool CheckDirection()
   {
      Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.2f, Color.red);

      RaycastHit hit;
      if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f, layerMask))
      {
         return hit.collider != null;
      }
      return false;
   }
   private void CheckDirectionAround()
   {
      RaycastHit hit;
      if (Physics.Raycast(transform.position, Vector3.forward, out hit, distanceRayCast, layerMask))
      {
        // Debug.Log( hit.collider.name);
         _canMoveForward = false;
      }
      else
      {
         _canMoveForward = true;
      }
      Debug.DrawRay(transform.position, Vector3.forward * distanceRayCast, Color.green);

      if (Physics.Raycast(transform.position, Vector3.back, out hit, distanceRayCast, layerMask))
      {
         _canMoveBack = false;

      }
      else
      {
         _canMoveBack = true;
      }
      Debug.DrawRay(transform.position, Vector3.back * distanceRayCast, Color.yellow);

      if (Physics.Raycast(transform.position, Vector3.left, out hit, distanceRayCast, layerMask))
      {
         //Debug.Log( hit.collider.name);
         _canMoveLeft = false;

      }
      else
      {
         _canMoveLeft = true;
      }
      Debug.DrawRay(transform.position, Vector3.left * distanceRayCast, Color.blue);

      if (Physics.Raycast(transform.position, Vector3.right, out hit, distanceRayCast, layerMask))
      {
         //Debug.Log( hit.collider.name);
         _canMoveRight = false;

      }
      else
      {
         _canMoveRight = true;
      }
      Debug.DrawRay(transform.position, Vector3.right * distanceRayCast, Color.red);
   }

   public void OnCollectionBrick()
   {
      Debug.Log("collect");
      int brickCount = collect.childCount;
      Vector3 spawnPos = collect.position + Vector3.up * brickCount * 0.3f;
      player.position =new Vector3(spawnPos.x, spawnPos.y + 0.16f,spawnPos.z);
      var collectedBrick = Instantiate(brickPrefab, spawnPos, Quaternion.Euler(new Vector3(-90,0,-180)), collect);
      m_ListCollectedBrick.Add(collectedBrick);
   }

   public void UnCollectionBrick()
   {
      if (m_ListCollectedBrick.Count > 0)
      {
         GameObject lastBrick = m_ListCollectedBrick[m_ListCollectedBrick.Count - 1];
         Destroy(lastBrick);
         m_ListCollectedBrick.RemoveAt(m_ListCollectedBrick.Count - 1);
         int brickCount = collect.childCount;
         Vector3 spawnPos = collect.position + Vector3.up * brickCount * 0.3f;
         player.position = new Vector3(spawnPos.x, spawnPos.y - 0.3f, spawnPos.z);
      }
      
   }

   public void OnWin()
   {
      _moveDirection = Vector3.zero;
   }
}
