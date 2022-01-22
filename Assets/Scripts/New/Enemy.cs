using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachines Brain;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private PlayerController tooth;

    private bool toothNear;
    private bool canAttack;

    private float change;

    private float AttackTimer;

    // Start is called before the first frame update
    void Start()
    {
        Brain = GetComponent<StateMachines>();
        Brain.pushState(Idle, OnIdleEnter);
    }

    // Update is called once per frame
    void Update()
    {
        //if the distance between enemy and player is less than 5 then this is true;
        toothNear = Vector3.Distance(transform.position, tooth.transform.position) < 3;
        //like above but this time if we are even closer than attack
        canAttack = Vector3.Distance(transform.position, tooth.transform.position) < 0.5f;

    }

    void OnIdleEnter()
    {
        agent.ResetPath();
    }
    void Idle() 
    {
        //our Idle state, nothing happens here but this helps make transitions between states smmoother
        change -= Time.deltaTime;
        if (toothNear)
        {
            Brain.pushState(Chase, null);
        }

        else if(change <= 0)
        {
            Brain.pushState(Walk, OnWalkEnter);

            change = Random.Range(1, 2);
        }
    }

    void Chase()
    {
        //set our enemy destination to be our tooth/player
        agent.SetDestination(tooth.transform.position);

        if(Vector3.Distance(transform.position, tooth.transform.position) > 3)
        {
            Brain.pushState(Idle, OnIdleEnter);
        }
        if (canAttack)
        {
            Brain.pushState(Attack, OnAttackEnter);
        }
    }

    void OnWalkEnter()
    {
        //Enemy walk direction, imagine a sphere around the enemy its finding a point inside that
        Vector3 walkDirection = (Random.insideUnitSphere * 10f) + transform.position;
        //that found point is our "navHit"
        NavMesh.SamplePosition(walkDirection, out NavMeshHit navHit, 3f, NavMesh.AllAreas);
        //make our destination navHit
        Vector3 destination = navHit.position;
        //set our destination
        agent.SetDestination(destination);
    }

    void Walk()
    {
        //if we are nearby stop moving towards it, this just helps prevent it from bugging
        if(agent.remainingDistance <= 0.25f)
        {
            //go back to Idle and clear our path
            agent.ResetPath();
            Brain.pushState(Idle, OnIdleEnter);
        }

        //if the tooth is near jump into chase state
        if (toothNear)
        {
            Brain.pushState(Chase, null);
        }
    }

    void OnAttackEnter()
    {
        agent.ResetPath();
    }

    void Attack()
    {
        AttackTimer -= Time.deltaTime;
        //if we are nearby and the timer is 0 then take damage
        if(AttackTimer <= 0)
        {
            HeathManager.HInstance.TakeDamage();
        }
        //if the distance between the enemy and player is too much then go back to idle
        if(Vector3.Distance(transform.position, tooth.transform.position) > 0.5f)
        {
            canAttack = false;
            Brain.pushState(Idle, OnIdleEnter);
        }
    }
}
