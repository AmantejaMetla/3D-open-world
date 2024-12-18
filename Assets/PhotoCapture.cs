using UnityEngine;

public class PhotoCapture : MonoBehaviour
{
    private int photoCount = 0; // To count saved photos

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // Press 'P' to capture
        {
            string photoName = "Photo_" + photoCount + ".png";
            ScreenCapture.CaptureScreenshot(photoName);
            Debug.Log("Captured photo: " + photoName);
            photoCount++;
        }
    }
}

