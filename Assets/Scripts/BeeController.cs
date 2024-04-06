/*using UnityEngine;
using System.Collections;

public class BeeController : MonoBehaviour
{
    Rigidbody rb;
    Quaternion originalRotation;
    Quaternion targetRotation;
    bool isRotating = false;
    bool isDescending = false;

    // Variables for controlling the bee's movement
    public float flyForce = 10f;
    public float rotationAngle = 45f; // Angle for rotation
    public float rotationSpeed = 5f; // Speed of rotation
    public float descentSpeed = 2f; // Speed of descent

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Disable gravity initially
        rb.useGravity = false;
        originalRotation = transform.rotation; // Store the original rotation
        targetRotation = originalRotation; // Initialize target rotation to original rotation
    }

    void Update()
    {
        // Upward movement control (Spacebar)
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

        // Forward movement (W)
        if (Input.GetKey(KeyCode.W))
        {
            // Move the bee forward
            transform.Translate(Vector3.forward * Time.deltaTime * flyForce);
        }

        // Backward movement (S)
        if (Input.GetKey(KeyCode.S))
        {
            // Move the bee backward
            transform.Translate(-Vector3.forward * Time.deltaTime * flyForce);
        }

        // Rotation to the left (A)
        if (Input.GetKeyDown(KeyCode.A) && !isRotating)
        {
            isRotating = true;
            // Rotate the bee to the left by the specified angle
            targetRotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, rotationAngle));
        }

        // Rotation to the right (D)
        if (Input.GetKeyDown(KeyCode.D) && !isRotating)
        {
            isRotating = true;
            // Rotate the bee to the right by the specified angle
            targetRotation = Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0f, 0f, rotationAngle));
        }

        // Rotate the bee if target rotation is set
        if (isRotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            // Check if rotation is close to target rotation
            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                // Snap to target rotation and reset rotation flag
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }

        // Check if neither 'A' nor 'D' is pressed and rotation is not zero
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && transform.rotation != originalRotation && !isRotating)
        {
            // Gradually return rotation to zero
            targetRotation = originalRotation;
            isRotating = true;
        }

        // Descent control (Z)
        if (Input.GetKeyDown(KeyCode.Z) && !isDescending)
        {
            isDescending = true;
            // Disable gravity to allow controlled descent
            rb.useGravity = false;
        }

        // Stop descending when 'Z' key is released
        if (Input.GetKeyUp(KeyCode.Z))
        {
            isDescending = false;
            // Enable gravity to make the bee stay at the current position
            rb.useGravity = true;
        }

        // If descending, gradually reduce altitude until grounded
        if (isDescending)
        {
            // Calculate the next position
            Vector3 nextPosition = transform.position + Vector3.down * Time.deltaTime * descentSpeed;
            // Check if the next position is below the ground level
            if (nextPosition.y <= 0f)
            {
                // Ensure the bee doesn't sink below the ground
                nextPosition.y = 0f;
                // Stop descending and enable gravity
                isDescending = false;
                rb.useGravity = true;
            }
            // Move the bee to the next position
            transform.position = nextPosition;
        }
    }
}
*/
/*using UnityEngine;
using System.Collections;

public class BeeController : MonoBehaviour
{
    Rigidbody rb;
    Quaternion originalRotation;
    Quaternion targetRotation;
    bool isRotating = false;
    bool isDescending = false;

    // Variables for controlling the bee's movement
    public float flyForce = 10f;
    public float rotationAngle = 45f; // Angle for rotation
    public float rotationSpeed = 5f; // Speed of rotation
    public float descentSpeed = 2f; // Speed of descent

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Disable gravity initially
        rb.useGravity = false;
        originalRotation = transform.rotation; // Store the original rotation
        targetRotation = originalRotation; // Initialize target rotation to original rotation
    }

    void Update()
    {
        // Upward movement control (Spacebar)
        if (Input.GetKey(KeyCode.Space))
        {
            // Enable gravity
            rb.useGravity = true;
            // Get the direction of the top face of the box
            Vector3 upwardDirection = transform.up;
            // Add an upward force to the bee in the direction of the top face
            rb.AddForce(upwardDirection * flyForce);
        }
        else
        {
            // Disable gravity when space is released
            rb.useGravity = false;
            // Stop the bee's upward movement by setting its velocity to zero
            rb.velocity = Vector3.zero;
        }

        // Forward movement (W)
        if (Input.GetKey(KeyCode.W))
        {
            // Move the bee forward
            transform.Translate(Vector3.forward * Time.deltaTime * flyForce);
        }

        // Backward movement (S)
        if (Input.GetKey(KeyCode.S))
        {
            // Move the bee backward
            transform.Translate(-Vector3.forward * Time.deltaTime * flyForce);
        }

        // Rotation to the left (A)
        if (Input.GetKeyDown(KeyCode.A) && !isRotating)
        {
            isRotating = true;
            // Rotate the bee to the left by the specified angle
            targetRotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, rotationAngle));
        }

        // Rotation to the right (D)
        if (Input.GetKeyDown(KeyCode.D) && !isRotating)
        {
            isRotating = true;
            // Rotate the bee to the right by the specified angle
            targetRotation = Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0f, 0f, rotationAngle));
        }

        // Rotate the bee if target rotation is set
        if (isRotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            // Check if rotation is close to target rotation
            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                // Snap to target rotation and reset rotation flag
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }

        // Check if neither 'A' nor 'D' is pressed and rotation is not zero
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && transform.rotation != originalRotation && !isRotating)
        {
            // Gradually return rotation to zero
            targetRotation = originalRotation;
            isRotating = true;
        }

        // Descent control (Z)
        if (Input.GetKeyDown(KeyCode.Z) && !isDescending)
        {
            isDescending = true;
            // Disable gravity to allow controlled descent
            rb.useGravity = false;
        }

        // Stop descending when 'Z' key is released
        if (Input.GetKeyUp(KeyCode.Z))
        {
            isDescending = false;
            // Enable gravity to make the bee stay at the current position
            rb.useGravity = true;
        }

        // If descending, gradually reduce altitude until grounded
        if (isDescending)
        {
            // Calculate the next position
            Vector3 nextPosition = transform.position + Vector3.down * Time.deltaTime * descentSpeed;
            // Check if the next position is below the ground level
            if (nextPosition.y <= 0f)
            {
                // Ensure the bee doesn't sink below the ground
                nextPosition.y = 0f;
                // Stop descending and enable gravity
                isDescending = false;
                rb.useGravity = true;
            }
            // Move the bee to the next position
            transform.position = nextPosition;
        }
    }
}
*/

using UnityEngine;

public class BeeController : MonoBehaviour
{
    Rigidbody rb;
    Quaternion originalRotation;
    Quaternion targetRotation;
    bool isRotating = false;
    bool isDescending = false;

    // Variables for controlling the bee's movement
    public float flyForce = 10f;
    public float rotationAngle = 45f; // Angle for rotation
    public float rotationSpeed = 5f; // Speed of rotation
    public float descentSpeed = 2f; // Speed of descent

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Disable gravity initially
        rb.useGravity = false;
        originalRotation = transform.rotation; // Store the original rotation
        targetRotation = originalRotation; // Initialise target rotation to original rotation
    }

    void Update()
    {
        // Upward movement control (Spacebar)
        if (Input.GetKey(KeyCode.Space))
        {
            // Enable gravity
            rb.useGravity = true;
            // Get the direction of the top face of the box
            Vector3 upwardDirection = transform.up;
            // Add an upward force to the bee in the direction of the top face
            rb.AddForce(upwardDirection * flyForce);
        }
        else
        {
            // Disable gravity when space is released
            rb.useGravity = false;
            // Stop the bee's upward movement by setting its velocity to zero
            rb.velocity = Vector3.zero;
        }

        // Forward movement (S)
        if (Input.GetKey(KeyCode.S))
        {
            // Move the bee forward
            transform.Translate(Vector3.forward * Time.deltaTime * flyForce);
        }

        // Backward movement (W)
        if (Input.GetKey(KeyCode.W))
        {
            // Move the bee backward
            transform.Translate(-Vector3.forward * Time.deltaTime * flyForce);
        }

        // Rotation to the left (d)
        if (Input.GetKeyDown(KeyCode.D) && !isRotating)
        {
            isRotating = true;
            // Rotate the bee to the left by the specified angle
            targetRotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, rotationAngle));
        }

        // Rotation to the right (a)
        if (Input.GetKeyDown(KeyCode.A) && !isRotating)
        {
            isRotating = true;
            // Rotate the bee to the right by the specified angle
            targetRotation = Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0f, 0f, rotationAngle));
        }

        // Rotate the bee if target rotation is set
        if (isRotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            // Check if rotation is close to target rotation
            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                // Snap to target rotation and reset rotation flag
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }

        // Check if neither 'A' nor 'D' is pressed and rotation is not zero
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && transform.rotation != originalRotation && !isRotating)
        {
            // Gradually return rotation to zero
            targetRotation = originalRotation;
            isRotating = true;
        }

        // Descent control (Q)
        if (Input.GetKeyDown(KeyCode.Q) && !isDescending)
        {
            isDescending = true;
            // Disable gravity to allow controlled descent
            rb.useGravity = false;
        }

        // Stop descending when 'Q' key is released
        if (Input.GetKeyUp(KeyCode.Q))
        {
            isDescending = false;
            // Enable gravity to make the bee stay at the current position
            rb.useGravity = true;
        }

        // If descending, gradually reduce altitude until grounded
        if (isDescending)
        {
            // Calculate the next position
            Vector3 nextPosition = transform.position + Vector3.down * Time.deltaTime * descentSpeed;
            // Check if the next position is below the ground level
            if (nextPosition.y <= 0f)
            {
                // Ensure the bee doesn't sink below the ground
                nextPosition.y = 0f;
                // Stop descending and enable gravity
                isDescending = false;
                rb.useGravity = true;
            }
            // Move the bee to the next position
            transform.position = nextPosition;
        }
    }
}
