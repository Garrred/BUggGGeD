using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float followSpeed = 10;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public Vector2 offset;
    public Vector2 smoothedPosition;

    void FixedUpdate()
    {
        if (playerTransform != null)
        {
            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);
            Vector2 targetPosition = new Vector2(clampedX, clampedY) + offset;
            smoothedPosition = Vector2.Lerp(transform.position, targetPosition, followSpeed * Time.fixedDeltaTime);
        }
    }
    private void LateUpdate()
    {
        transform.position = smoothedPosition;
    }
}
