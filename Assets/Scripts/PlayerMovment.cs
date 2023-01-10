using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    //serialized fields
    [SerializeField]
    [Min(1)]
    private float moveSpeed;
   
    [SerializeField] 
    float m_topSpeed = 10;

    [SerializeField]
    private Vector2 jumpForce;

    [SerializeField]
    public BoxCollider2D groundDetector;

    //private fields
    private bool jumpReset;
    private Rigidbody2D rb;
    private Vector2 m_currentMove;

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
            // add jump force if jump is available
           rb.AddForce(jumpForce);
           jumpReset = false; //prevents multiple jumps
        }       
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

    }

    private void FixedUpdate()
    {
        rb.AddForce(m_currentMove * moveSpeed); 
        if(rb.velocity.magnitude > m_topSpeed) //clamps movement to topspeed
        {
            rb.AddForce(-m_currentMove * moveSpeed);
        }
    }
}
