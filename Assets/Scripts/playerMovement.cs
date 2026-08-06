using UnityEngine;
using TMPro;
public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float jump_speed = 10f;
    public float gravity = -10f;
    public float ground_distance = 0.5f;

    public float inversion_probability;
    public float inversion_duration;
    
    Vector3 velocity;
    float x,z;
    bool isGrounded;
    bool isInverted;
    [SerializeField] TextMeshProUGUI text_inverted;

    public Transform GroundCheck;
    public LayerMask groundmask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void undo_inversion()
    {
        isInverted = false;
        text_inverted.text = "";
    }

    void FixedUpdate()
    {
        if(Random.Range(0f,100f) < inversion_probability && !isInverted)
        {
            isInverted = true;
            text_inverted.text = "INVERTED CONTROLS ON!";
            Invoke(nameof(undo_inversion),inversion_duration);
        }    
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
        if (isInverted)
        {
            move *= -1f;
        }
        controller.Move(move*speed*Time.deltaTime);

        velocity.y += gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }

}
