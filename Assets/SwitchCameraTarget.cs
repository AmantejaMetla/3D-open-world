using UnityEngine;
using Cinemachine;

public class SwitchCameraTarget : MonoBehaviour
{
    public CinemachineVirtualCamera playerFollowCamera;
    public Transform playerCameraRoot;
    public Transform aircraftFollowTarget;

    private bool isInAircraft = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isInAircraft)
            {
                EnterAircraft();
            }
            else
            {
                ExitAircraft();
            }
        }
    }

    void EnterAircraft()
    {
        playerFollowCamera.Follow = aircraftFollowTarget;
        isInAircraft = true;
    }

    void ExitAircraft()
    {
        playerFollowCamera.Follow = playerCameraRoot;
        isInAircraft = false;
    }
}
