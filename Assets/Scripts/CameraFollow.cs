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

    void FixedUpdate()
    {
        if (playerTransform != null)
        {
            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);
            Vector2 targetPosition = new Vector2(clampedX, clampedY) + offset;
            Vector2 smoothedPosition = Vector2.Lerp(transform.position, targetPosition, followSpeed * Time.fixedDeltaTime);
            transform.position = smoothedPosition;
        }
    }
}
