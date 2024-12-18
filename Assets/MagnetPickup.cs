using UnityEngine;

public class MagnetPickup : MonoBehaviour
{
    public Transform ropeAttachPoint; // Where objects stick to the magnet
    private GameObject attachedObject; // Object currently picked up

    void OnTriggerEnter(Collider other)
    {
        // Check if the magnet is touching a pickable object
        if (attachedObject == null && other.CompareTag("Pickable"))
        {
            attachedObject = other.gameObject;

            // Attach object to magnet
            attachedObject.transform.SetParent(ropeAttachPoint);
            attachedObject.transform.localPosition = Vector3.zero;
            attachedObject.GetComponent<Rigidbody>().isKinematic = true; // Stop physics
            Debug.Log("Object Attached: " + attachedObject.name);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && attachedObject != null) // Drop object
        {
            attachedObject.GetComponent<Rigidbody>().isKinematic = false;
            attachedObject.transform.SetParent(null);
            Debug.Log("Object Dropped: " + attachedObject.name);
            attachedObject = null; // Detach the object
        }
    }
}

