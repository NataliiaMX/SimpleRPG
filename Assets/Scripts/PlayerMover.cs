using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Ray lastRay;

    private void Update() 
    {
        MovePlayer();    
    }

    private void MovePlayer()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MoveToRay();
        }
        
    }

    private void MoveToRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; 
        bool hasHit = Physics.Raycast(ray, out hit); //store information about where the raycast hit in "hit" variable

        if(hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }
}
