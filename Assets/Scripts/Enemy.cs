using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float stoppingDistance;

    NavMeshAgent agent;

    GameObject target;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if(dist < 2.5)
        {
            EnemyAttack();
        }
        else
        {
            GoToTarget();
        }

    }

    private void GoToTarget()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
    }

    private void EnemyAttack()
    {
        agent.isStopped = true;
    }

}
