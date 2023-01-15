using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //public fields
    public bool Flipped;

    //serialized fields
    [SerializeField]
    [Min(1)]
    private float moveSpeed;

    [SerializeField]
    float m_topSpeed = 10;

    [SerializeField]
    private Vector2 jumpForce;

    [SerializeField]
    [Min(0)]
    private float midAirControlDelay;

    [SerializeField]
    public BoxCollider2D groundDetector;

    //private fields
    private bool jumpReset;
    private bool isJumping;
    private Rigidbody2D rb;
    private Vector2 m_currentMove;

    private bool movementEnabled = true;
    private float jumpTimer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        m_currentMove = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpReset == true)
        {
            if (!Flipped)
            {
                // add jump force if jump is available
                rb.AddForce(jumpForce);
            }
            else
            {
                // add -jump force if jump is available
                rb.AddForce(-jumpForce);
            }
            jumpReset = false; //prevents multiple jumps       
            isJumping = true;
        }
        //sets player to jump        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        jumpReset = false;  //prevents multiple jumps
    }

    public void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interact button pressed");
    }

    public void Magnet(InputAction.CallbackContext context)
    {
        Debug.Log("Magnet button pressed");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //reset jump when player ground detector leaves the ground
        jumpReset = true;
        Debug.Log("jump reset");
    }

    // Update is called once per frame
    void Update()
    {
        //code for mid air control delay
        if (jumpReset == false)
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer > midAirControlDelay) //delays movement until a certain part of the players jump after time has passed
            {
                movementEnabled = true;
            }
            else
            {
                movementEnabled = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (movementEnabled)
        {
            //accelerates in direction of pressed input
            rb.AddForce(m_currentMove * moveSpeed);
            if (rb.velocity.magnitude > m_topSpeed) //clamps movement to topspeed
            {
                rb.AddForce(-m_currentMove * moveSpeed);
            }
        }

        if (isJumping)
        {
            //if player is falling before they jump then this cancels out their velocity
            float currentVelocity = new();
            currentVelocity = rb.velocity.y;

            jumpForce.y += -currentVelocity;

            //stops jump after adding jumpforce
            rb.AddForce(jumpForce);
            isJumping = false;
        }
    }
}
