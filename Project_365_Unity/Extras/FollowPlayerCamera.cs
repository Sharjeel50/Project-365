using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
