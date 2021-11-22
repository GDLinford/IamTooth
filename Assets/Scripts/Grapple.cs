using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//also made with the same tutorial as the hook

public class Grapple : MonoBehaviour
{

    [SerializeField]
    private InputActionReference shootControl;

    [SerializeField] float PullSpeed = 0.5f;
    [SerializeField] float stoppingDist = 4f;
    [SerializeField] GameObject hookPrefab;
    [SerializeField] Transform transformShoot;

    Hook hook;
    bool isPulling;
    Rigidbody rigidbody;

    [HideInInspector]
    public bool GrappleFired;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        isPulling = false;
    }

    private void OnEnable()
    {
        shootControl.action.Enable();
    }

    private void OnDisable()
    {
        shootControl.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(hook == null && shootControl.action.triggered)
        {
            GrappleFired = true;
            StopAllCoroutines();
            isPulling = false;
            hook = Instantiate(hookPrefab, transformShoot.position, Quaternion.identity).GetComponent<Hook>();
            hook.Initialize(this, transformShoot);
            StartCoroutine(HookGoneAfterTime());
        }
        //else if(hook !=)

        if (!isPulling || hook == null)
            return;

        if(Vector3.Distance(transform.position, hook.transform.position) <= stoppingDist)
        {
            DestroyHook();
        }
        else
        {
            rigidbody.AddForce((hook.transform.position - transform.position).normalized * PullSpeed, ForceMode.VelocityChange);
        }
    }

    public void StartPull()
    {
        isPulling = true;
    }

    private void DestroyHook()
    {
        if (hook == null)
            return;

        isPulling = false;
        Destroy(hook.gameObject);
        hook = null;
    }

    private IEnumerator HookGoneAfterTime()
    {
        yield return new WaitForSeconds(8f);

        DestroyHook();
    }
}
