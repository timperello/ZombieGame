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

    private int Z_Health=3;

    private bool isCoroutineExecuting;
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
        if(Z_Health <= 0)
        {
            agent.isStopped = true;
            anim.Play("Z_FallingBack");
            Destroy(gameObject,1);
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
    private void TakeDmg(int nbDegat)
    {
        this.Z_Health -= nbDegat;
    }
    IEnumerator SlowZombie(float time)
    {
        if (isCoroutineExecuting)
            yield break;
        agent.speed = 1;
        anim.Play("Z_Walk_InPlace");
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        if (Z_Health > 0)
        {
            agent.speed = 3;
            anim.Play("Z_Run_InPlace");
        }
        isCoroutineExecuting = false;
    }
}
