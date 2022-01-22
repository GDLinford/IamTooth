using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightPatrol : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform target;

    private int TargetWaypointNumber = 0;
    private float minDist = 0.1f;
    private int lastWaypointNum;

    [SerializeField] private float MoveSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        lastWaypointNum = waypoints.Count - 1;
        target = waypoints[TargetWaypointNumber];
    }

    // Update is called once per frame
    void Update()
    {
        float moveStep = MoveSpeed * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, target.position);
        CheckDistance(distance);

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveStep);
    }

    void CheckDistance(float curDistance)
    {
        if(curDistance <= minDist)
        {
            TargetWaypointNumber++;
            ChangeTarget();
        }
    }

    void ChangeTarget()
    {
        //go the next waypoint
        if(TargetWaypointNumber > lastWaypointNum)
        {
            TargetWaypointNumber = 0;
        }
        target = waypoints[TargetWaypointNumber];
    }
}
