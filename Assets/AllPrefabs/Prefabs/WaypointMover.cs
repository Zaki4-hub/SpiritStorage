using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
   
    [SerializeField] private Waypoints waypoints;
    [SerializeField] public float moveSpeed = 5f;
    private Transform currentWaypoint;
    [SerializeField] private float distanceThreshold = 0.1f;
 

    public static Action<int> WaypointChanged;
    void Start()
    {
        currentWaypoint = waypoints.GetToTheNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;
        currentWaypoint = waypoints.GetToTheNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);

    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed*Time.deltaTime);
        if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
           
            currentWaypoint = waypoints.GetToTheNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
            WaypointChanged?.Invoke(currentWaypoint.GetSiblingIndex());
        }
    }
}
