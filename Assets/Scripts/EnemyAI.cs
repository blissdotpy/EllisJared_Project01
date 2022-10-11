using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : Enemy
{
    public NavMeshAgent agent;
    public float range;

    public Transform centrePoint;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if (!(agent.remainingDistance <= agent.stoppingDistance)) return; 
        if (!RandomPoint(centrePoint.position, range, out var point)) return;
        Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
        agent.SetDestination(point);

    }

    static bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        if (NavMesh.SamplePosition(randomPoint, out var hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

}
