using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chandelierReset : MonoBehaviour
{
    [SerializeField] private GameObject Chandelier1;

    void ChandelierIncasePlayerFallsOff()
    {
        //this is just made so if the player falls off then the chandelier will come back down
        Chandelier1.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
