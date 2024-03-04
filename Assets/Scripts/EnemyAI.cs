using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float vievAngle;
    public float damage = 20;

    private NavMeshAgent _navMeshAgent;
    private bool _IsplayerNoticed;
    private PlayerHealth _playerHealth;

    void Start()
    {
        initComponentLinks();
        PickNewPatrolPoint();
        _playerHealth=player.GetComponent<PlayerHealth>();


    }

    void Update()
    {
        NoticePlayerUpdate();

        ChaseUpdate();
        PatrolUpdate();
        AttackUpdate();
    }   
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void PatrolUpdate()
    {
        if (!_IsplayerNoticed)
        {
            if (_navMeshAgent.remainingDistance<=_navMeshAgent.stoppingDistance)
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
    private void AttackUpdate()
    {
        if (_IsplayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {

                _playerHealth.DealDamage(damage * Time.deltaTime);
            }
        }
    }
}
