using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{

    private Vector3 PlayerMoveInput;
    private Vector2 playerMouseInput;

    private float Xrot;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody rigidbody;

    public float speed;
    public float sensitivity;
    public float JumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MoveCamera();
    }

    private void MovePlayer()
    {
        Vector3 MoveVec3 = transform.TransformDirection(PlayerMoveInput) * speed;
        rigidbody.velocity = new Vector3(MoveVec3.x, rigidbody.velocity.y, MoveVec3.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    private void MoveCamera()
    {
        Xrot -= playerMouseInput.y * sensitivity;

        transform.Rotate(0f, playerMouseInput.x * sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(Xrot, 0f, 0f);
    }

}
