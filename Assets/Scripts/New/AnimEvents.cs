using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour
{
    //this script is being made to store any animation event that need to happen

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
