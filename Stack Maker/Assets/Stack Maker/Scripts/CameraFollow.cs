using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetPlayer;
    public Vector3 offset;
    public Vector3 rotation;
    public float speed;
    private void Start()
    {
        targetPlayer = FindObjectOfType<Player>().transform;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPlayer.position + offset, Time.fixedTime* speed);
        transform.rotation = Quaternion.Euler(rotation);

    }
}