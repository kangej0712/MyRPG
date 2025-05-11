using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          // ���� ��� (Player)
    public Vector3 offset;            // ī�޶� ��ġ ������
    public float smoothSpeed = 0.125f;

    // �̵� ���� ���� ��
    public Vector2 minPos;
    public Vector2 maxPos;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // ��ġ ���� ����
        float clampedX = Mathf.Clamp(desiredPosition.x, minPos.x, maxPos.x);
        float clampedY = Mathf.Clamp(desiredPosition.y, minPos.y, maxPos.y);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
