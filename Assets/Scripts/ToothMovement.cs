//using UnityEngine;
//using UnityEngine.InputSystem;

//[RequireComponent(typeof(CharacterController))]
//public class ToothMovement : MonoBehaviour
//{
   
//    public InputActionReference moveControl;
//    [SerializeField]
//    private InputActionReference jump;
//    public InputActionReference climbUp;
//    public InputActionReference climbDown;
//    [SerializeField]
//    private float playerSpeed = 2.0f;
//    [SerializeField]
//    private float jumpHeight = 1.0f;

//    Grapple grapple;

//    private CharacterController controller;
//    private Vector3 playerVelocity;
//    private bool groundedPlayer;
//    private float gravityValue = -9.81f;
//    private Transform cameraMTransform;

//    [SerializeField] private float climbSpeed = 100f;

//    private void OnEnable()
//    {
//        moveControl.action.Enable();
//        jump.action.Enable();
//    }

//    private void OnDisable()
//    {
//        moveControl.action.Disable();
//        jump.action.Disable();
//    }

//    private void Start()
//    {
//        controller = gameObject.GetComponent<CharacterController>();
//        cameraMTransform = Camera.main.transform;
//        grapple = GetComponent<Grapple>();
       
        
//    }

//    void Update()
//    {
//        groundedPlayer = controller.isGrounded;
//        if (groundedPlayer && playerVelocity.y < 0)
//        {
//            playerVelocity.y = 0f;
//        }
        
//        Vector2 movement = moveControl.action.ReadValue<Vector2>();
        
//        Vector3 move = new Vector3(movement.x, 0, movement.y);
//        //move in the direction the camera is facing
//        move = cameraMTransform.forward * move.z + cameraMTransform.right * move.x;
//        move.y = 0;

//        controller.Move(move * Time.deltaTime * playerSpeed);

//        // Changes the height position of the player..
//        if (jump.action.triggered && groundedPlayer)
//        {
//            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
//        }

//        playerVelocity.y += gravityValue * Time.deltaTime;
//        controller.Move(playerVelocity * Time.deltaTime);

//        //if (canClimb && climbUp.action.triggered)
//        //{
//        //    //controller.transform.position = Vector3.Lerp(controller.transform.position, climb.exit.position, climbSpeed * Time.deltaTime);
//        //    controller.gameObject.transform.position = climb.exit.transform.position;
//        //}

//    }

//    void OnTriggerEnter(Collider other)
//    {

//    }

//    void OnTriggerExit(Collider other)
//    {

//    }
//}
