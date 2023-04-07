using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update() 
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = target.position;
    }
}
