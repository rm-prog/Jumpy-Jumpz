using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    // Position of player
    public Transform target;

    // Maximum y position of camera
    private float maxYPosition = 7f;

    // 10f
    // How fast camera changes rotation depending on player movement
    private float smoothSpeed = 8f;

    // -14, 6, 0
    // The difference between player position and camera position
    private Vector3 offset = new Vector3(-8, 1.2f, 0);

    void FixedUpdate()
    {
        if (target != null)
        {
            // Change the position of target
            Vector3 desiredPosition = target.position + offset;
            // desiredPosition.Set(desiredPosition.x, desiredPosition.y, transform.position.z);
            // Make transition from current position to desiredPosition smoothly
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            if (smoothedPosition.y > maxYPosition)
            {
                smoothedPosition.Set(smoothedPosition.x, maxYPosition, smoothedPosition.z);
            }
            transform.position = smoothedPosition;
        }
    }

}
