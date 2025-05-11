using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public AudioClip eatSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(eatSound, transform.position);
            Destroy(gameObject);
        }
    }
}
