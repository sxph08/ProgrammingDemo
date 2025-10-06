using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 200f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.3f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Prevent player from tipping over
        rb.freezeRotation = true;
    }

    void Update()
    {
        float moveDirection = Input.GetAxis("Vertical");
        float turnDirection = Input.GetAxis("Horizontal");

        // Rotate the player
        transform.Rotate(Vector3.up * turnDirection * turnSpeed * Time.deltaTime);

        // Check if grounded (before moving or jumping)
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Move the player forward (keep Y velocity unchanged)
        Vector3 move = transform.forward * moveDirection * moveSpeed;
        Vector3 newVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
        rb.linearVelocity = newVelocity;

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}