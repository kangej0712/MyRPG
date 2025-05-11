using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          // 따라갈 대상 (Player)
    public Vector3 offset;            // 카메라 위치 오프셋
    public float smoothSpeed = 0.125f;

    // 이동 범위 제한 값
    public Vector2 minPos;
    public Vector2 maxPos;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // 위치 제한 적용
        float clampedX = Mathf.Clamp(desiredPosition.x, minPos.x, maxPos.x);
        float clampedY = Mathf.Clamp(desiredPosition.y, minPos.y, maxPos.y);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
