using UnityEngine;

public class BeeController : MonoBehaviour
{
    Rigidbody rb;

    // Variables for controlling the bee's movement
    public float flyForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Disable gravity initially
        rb.useGravity = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Enable gravity
            rb.useGravity = true;
            // Add an upward force to the bee
            rb.velocity = Vector3.up * flyForce;
        }
        else
        {
            // Disable gravity when space is released
            rb.useGravity = false;
            // Stop the bee's upward movement by setting its velocity to zero
            rb.velocity = Vector3.zero;
        }
    }
}
