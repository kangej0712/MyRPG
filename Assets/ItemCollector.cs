using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dessert"))
        {
            Destroy(other.gameObject); // 아이템이 사라짐
            // 점수 증가, 효과음 추가 가능
        }
    }
}

