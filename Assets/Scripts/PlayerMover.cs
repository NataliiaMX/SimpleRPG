using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
{
    private Ray lastRay;

    private void Update() 
    {
        MovePlayer();    
    }

    private void MovePlayer()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MoveToRayHit();
        }
        UpdateAnimator();
    }

    private void MoveToRayHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; 
        bool hasHit = Physics.Raycast(ray, out hit); //store information about where the raycast hit in "hit" variable

        if(hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity); //converting global to local units
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
}
