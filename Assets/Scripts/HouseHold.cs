using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseHold : MonoBehaviour
{
    [HideInInspector]
    public StateMachines Brain;
    [HideInInspector]
    public bool hamsterNear;
    [HideInInspector]
    public BallMove hamster;

    [HideInInspector]
    public float change;
}
