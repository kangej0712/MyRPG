using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dessert"))
        {
            Destroy(other.gameObject); // �������� �����
            // ���� ����, ȿ���� �߰� ����
        }
    }
}

