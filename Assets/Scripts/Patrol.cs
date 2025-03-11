using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] waypoints;
    private NavMeshAgent agent;
    private int currentWaypoint = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            agent.Warp(hit.position);
            Debug.Log("Agent successfully placed on NavMesh.");
        }
        else
        {
            Debug.LogError("No valid NavMesh found near the agent's position.");
            return;
        }
    }

    void Update()
    {
        if (agent.isOnNavMesh)
        {
            Debug.Log($"Remaining distance: {agent.remainingDistance}, Velocity: {agent.velocity}");
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    MoveToNextWaypoint();
                }
            }
        }
        else
        {
            Debug.LogError("Agent is not on the NavMesh.");
        }
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(waypoints[currentWaypoint].position, out hit, 1.0f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
            Debug.Log($"Moving to waypoint {currentWaypoint}: {hit.position}");
        }
        else
        {
            Debug.LogError($"Waypoint {currentWaypoint} is not on the NavMesh!");
        }
    }
    
}
