using UnityEngine;

public class StayInBottomRight : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    public Vector3 offset = new Vector3(0, 0, 0); // Optional offset from the corner position

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Automatically use the main camera if none is assigned
        }
    }

    void Update()
    {
        // Get the bottom-right corner in the camera's viewport (normalized coordinates)
        Vector3 bottomRightViewport = new Vector3(1, 0, 10); // (x=1, y=0 is the bottom-right corner)

        // Convert the viewport position to world position
        Vector3 worldPosition = mainCamera.ViewportToWorldPoint(bottomRightViewport);

        // Apply the position and offset (optional)
        transform.position = worldPosition + offset;
    }
}
