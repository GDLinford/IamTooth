using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour
{
    //this script is being made to store any animation event that needs to happen, primarily used for changing how some of the rooms look after an objective is complete.

    [SerializeField] private GameObject objToActivate, secondObjtoActivate, thirdObjtoActivate, ObjtoDeactivate;

    public void UhOh()
    {
        objToActivate.SetActive(true);
        secondObjtoActivate.SetActive(true);
        thirdObjtoActivate.SetActive(true);
        ObjtoDeactivate.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
