using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathManager : MonoBehaviour
{
    public static HeathManager HInstance;
    [HideInInspector] public int curHealth;
    public int MaxHealth;

    public float InvulnLength;
    [SerializeField] private float InvulnTimer;

    private void Awake()
    {
        HInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthSet();
    }

    // Update is called once per frame
    void Update()
    {
        if(InvulnTimer > 0)
        {
            InvulnTimer -= Time.deltaTime;
        }

    }

    public void TakeDamage()
    {
        //every time we take damage apply some brief invincibilty and then take damage, if we enter a damage trigger during the invuln dont take damage

        if(InvulnTimer <= 0)
        {
            InvulnTimer = InvulnLength;

            curHealth = curHealth - 1;

            if (curHealth <= 0)
            {
                Manager.SInstance.RespawnPlayer();
            }

            UIManager.UInstance.HealthUpdate();
        }
    }

    public void HealthSet()
    {
        curHealth = MaxHealth;

        UIManager.UInstance.HealthUpdate();
    }
}
