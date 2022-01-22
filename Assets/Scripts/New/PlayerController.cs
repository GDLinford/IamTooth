using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController PCInstance;

    //public Material[] materials;
    //[HideInInspector] public MeshRenderer Mrenderer;

    public float speed;
    //jump and gravity
    public float JSpeed, gravityScale;

    private float yValue;

    public CharacterController charController;

    public Animator anim;

    //Camera
    [HideInInspector] public CameraController camera;
    [SerializeField] private GameObject cam1;
    public float rotSpeed = 10f;

    [HideInInspector] public Vector3 movement;

    [SerializeField] private bool grounded, groundedLast;

    public GameObject jumpParticle, landingParticle;

    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<CameraController>();

        groundedLast = true;

        //Mrenderer = GetComponent<MeshRenderer>();
        //Mrenderer.enabled = true;
        //Mrenderer.sharedMaterial = materials[0];
    }

    void FixedUpdate()
    {
        //if we are grounded then stop applying downward force
        //if we dont have this then the gravity wont stop building, so non jump false plummet like a stone.
        if (!charController.isGrounded)
        {
            movement.y = movement.y + (Physics.gravity.y * gravityScale * Time.fixedDeltaTime);
        }
        else
        {
            movement.y = Physics.gravity.y * gravityScale * Time.deltaTime;
        }

    }

    // Update is called once per frame
    void Update()
    {

        yValue = movement.y;

        playerMove();

        movement.y = 0f;

        //this just helps set our Y back to our gravity value after we set it to 0
        movement.y = yValue;

        if (charController.isGrounded)
        {
            grounded = true;
            jumpParticle.SetActive(false);
        }

        if(grounded && !groundedLast)
        {
            landingParticle.SetActive(true);
        }

        if (grounded && Input.GetButtonDown("Jump"))
        {
            grounded = false;
            movement.y = JSpeed;
            jumpParticle.SetActive(true);
        }

        //were we grounded in the frame
        groundedLast = charController.isGrounded;

        //changed this up to ensure we arent multiplying our gravity on Accident
        charController.Move(new Vector3(movement.x * speed, movement.y, movement.z * speed) * Time.deltaTime);

        
    }

    public void playerMove()
    {
        //use the camera direction to dictate where the player moves
        movement = (camera.transform.forward * Input.GetAxisRaw("Vertical")) + (camera.transform.right * Input.GetAxisRaw("Horizontal"));

        movement = movement.normalized;

        //are we moving the player
        if (movement.magnitude > 0.1f && movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotSpeed * Time.deltaTime);
        }
    }
}
