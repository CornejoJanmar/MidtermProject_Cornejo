using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI;

public class AIMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform centerPoint;
    public float range;
    public Transform player;

    public Color originalColor;
    public Color touchColor = Color.green;
    private bool isFollowingPlayer = false;
    private void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        originalColor = GetComponent<Renderer>().material.color;
    }
    
    private void Update()
    {  
        if(isFollowingPlayer)
        {
            FollowPlayer();
        }
        else if(isFollowingPlayer == false)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                Vector3 point;
                if(RandomPoint(centerPoint.position, range, out point))
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                    navMeshAgent.SetDestination(point);
                }
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    private void FollowPlayer()
    {
        if(player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowingPlayer = true;
            navMeshAgent.speed = 20;
            GetComponent<Renderer>().material.color = touchColor;
        }
    }
}
