using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    float lastAttackTime = 0;
    float attackCooldown = 3;

    [SerializeField] float stoppingDistance;

    NavMeshAgent agent;

    GameObject target;

    Animator anim;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if(dist < 2)
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
        if(Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            anim.Play("Z_Idle");
            anim.Play("Z_Attack");
        }
        
    }

}
