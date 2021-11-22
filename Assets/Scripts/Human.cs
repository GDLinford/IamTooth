using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : HouseHold
{
    private bool nearRemote;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private VideoConrol conrol;
    [SerializeField]
    private Remote remote;

    // Start is called before the first frame update
    void Start()
    {
        hamster = FindObjectOfType<BallMove>();
        agent = GetComponent<NavMeshAgent>();
        Brain = GetComponent<StateMachines>();
        Brain.pushState(Idle, OnIdleEnter);
        remote = FindObjectOfType<Remote>();
        conrol = FindObjectOfType<VideoConrol>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the distance between human and remote is less than 5 nearRemote = true
        nearRemote = Vector3.Distance(transform.position, remote.transform.position) < 20;

        if(conrol.shouldPlay == true)
        {
            agent.SetDestination(remote.transform.position);
        }

        else if (nearRemote == true)
        {
            conrol.shouldPlay = false;
            Brain.pushState(Idle, OnIdleEnter);
        }
    }

    void OnIdleEnter()
    {
        agent.ResetPath();
    }

    void Idle()
    {
        change -= Time.deltaTime;

        if (change <= 0)
        {
            Brain.pushState(Walk, WalkEnter);

            change = Random.Range(2, 5);
        }
    }

    void WalkEnter()
    {
        //every few seconds walk in a random direction
        Vector3 walkDirection = (Random.insideUnitSphere * 8f) + transform.position;
        NavMesh.SamplePosition(walkDirection, out NavMeshHit navHit, 3f, NavMesh.AllAreas);
        Vector3 destination = navHit.position;
        agent.SetDestination(destination);
    }

    void Walk()
    {

        if (agent.remainingDistance <= 0.25f)
        {
            agent.ResetPath();
            Brain.pushState(Idle, OnIdleEnter);
        }
    }
}