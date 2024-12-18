using UnityEngine;

public class PlayerRideAircraft : MonoBehaviour
{
    [Header("References")]
    public Transform seatPosition;             // Position where the player sits in the aircraft
    public Transform aircraftCameraPosition;   // Position for the camera while riding the aircraft
    public GameObject player;                  // Reference to the player GameObject
    public MonoBehaviour playerController;     // Player movement script to disable
    public AircraftController aircraftController; // Aircraft control script

    private bool isNearAircraft = false;       // Tracks if the player is close enough
    private bool isRiding = false;
    private Camera mainCamera;                 // Reference to the main camera

    void Start()
    {
        mainCamera = Camera.main; // Cache the main camera
    }

    void Update()
    {
        // Press E to ride or exit the aircraft
        if (isNearAircraft && Input.GetKeyDown(KeyCode.E) && !isRiding)
        {
            RideAircraft();
        }
        else if (isRiding && Input.GetKeyDown(KeyCode.E))
        {
            ExitAircraft();
        }
    }

    void RideAircraft()
    {
        // Parent the player to the aircraft's seat
        player.transform.SetParent(seatPosition);
        player.transform.localPosition = Vector3.zero; // Align player to seat position

        // Parent the camera to the aircraft
        Camera.main.transform.SetParent(aircraftController.transform);
        Camera.main.transform.localPosition = new Vector3(0, 2, -5); // Adjust camera position
        Camera.main.transform.localRotation = Quaternion.Euler(10, 0, 0); // Adjust camera angle

        // Disable player control and activate aircraft control
        playerController.enabled = false;
        aircraftController.Activate();

        isRiding = true;
        Debug.Log("You are now riding the aircraft!");
    }


    void ExitAircraft()
    {
        // Detach player from the aircraft
        player.transform.SetParent(null);

        // Reset the camera's parent to nothing (optional: place it back to follow the player)
        Camera.main.transform.SetParent(null);

        // Reset camera position relative to the player
        Camera.main.transform.position = player.transform.position + new Vector3(0, 2, -5);
        Camera.main.transform.LookAt(player.transform);

        // Enable player control and deactivate aircraft control
        playerController.enabled = true;
        aircraftController.Deactivate();

        isRiding = false;
        Debug.Log("You have exited the aircraft.");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isNearAircraft = true;
            Debug.Log("Press E to ride the aircraft");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isNearAircraft = false;
        }
    }
}
