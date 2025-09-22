using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipePlayer : MonoBehaviour,IDragHandler
{
    public static event Action<Vector3> OnSwipe;

    public void OnDrag(PointerEventData eventData)
    {
        OnSwipe?.Invoke(eventData.delta);
    }
}
