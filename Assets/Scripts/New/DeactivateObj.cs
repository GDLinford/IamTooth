using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObj : MonoBehaviour
{
    //like Activate this is just a very generic/simple script I can use when I need something deactivated

    [SerializeField] private GameObject objToDeactivate;

    public void DeactivateGameObj()
    {
        objToDeactivate.SetActive(false);
    }

}
