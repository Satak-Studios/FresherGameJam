using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float jump_speed = 10f;
    public float gravity = -10f;
    public float ground_distance = 0.5f;

    Vector3 velocity;
    float x,z;
    bool isGrounded;

    public Transform GroundCheck;
    public LayerMask groundmask;
    public Camera playerCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position,ground_distance,groundmask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += jump_speed;
        }

        Vector3 move = transform.forward * z + transform.right * x;
        controller.Move(move*speed*Time.deltaTime);

        velocity.y += gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
}
