using UnityEngine;

public class DeployRope : MonoBehaviour
{
    private bool isDeployed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Press R to deploy/retract
        {
            isDeployed = !isDeployed;
            gameObject.SetActive(isDeployed);
            Debug.Log("Rope " + (isDeployed ? "Deployed" : "Retracted"));
        }
    }
}

