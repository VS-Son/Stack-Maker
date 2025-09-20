using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;

public class PlayerDrag : MonoBehaviour, IDragHandler
{
    public static event Action<Vector3> OnMove; 
    public void OnDrag(PointerEventData eventData)
    {
        if (OnMove != null) OnMove.Invoke(eventData.delta);
    }

   
}
