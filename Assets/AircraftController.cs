using UnityEngine;

public class AircraftController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 20f;       // Forward speed
    public float turnSpeed = 50f;       // Rotation speed
    public float climbSpeed = 15f;      // Up/Down movement speed

    private bool isActive = false;      // To check if the aircraft is active

    void Start()
    {
        enabled = false; // Disable the script at the start
    }

    void Update()
    {
        if (!isActive) return;

        // Movement Controls
        float vertical = Input.GetAxis("Vertical");      // W/S for forward/backward
        float horizontal = Input.GetAxis("Horizontal");  // A/D for turning
        float climb = 0;

        if (Input.GetKey(KeyCode.Space))         // Space for climbing
            climb = 1f;
        else if (Input.GetKey(KeyCode.LeftControl)) // Left Ctrl for descending
            climb = -1f;

        // Apply movement
        Vector3 moveDirection = Vector3.forward * vertical + Vector3.up * climb;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Apply rotation
        transform.Rotate(Vector3.up, turnSpeed * horizontal * Time.deltaTime);
    }

    // Method to activate the aircraft
    public void Activate()
    {
        isActive = true;
        enabled = true;
    }

    // Method to deactivate the aircraft
    public void Deactivate()
    {
        isActive = false;
        enabled = false;
    }
}
