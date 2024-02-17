using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float vievAngle;

    private NavMeshAgent _navMeshAgent;
    private bool _IsplayerNoticed;
    void Start()
    {
        initComponentLinks();
        PickNewPatrolPoint();
    }

    void Update()
    {
        NoticePlayerUpdate();

        ChaseUpdate();
        PatrolUpdate();
    }   
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void PatrolUpdate()
    {
        if (!_IsplayerNoticed)
        {
            if (_navMeshAgent.remainingDistance == 0)
            {
                PickNewPatrolPoint();
            }
        }
    }
    private void initComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;

        _IsplayerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < vievAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _IsplayerNoticed = true;
                }
            }
        }
    }
    private void ChaseUpdate()
    {
        if (_IsplayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
}
