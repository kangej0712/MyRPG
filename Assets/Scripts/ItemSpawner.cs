using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public float spawnInterval = 1.5f;
    public float spawnXRange = 8f;
    public float spawnY = 6f; // 고정된 Y 위치로 스폰

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        if (itemPrefabs.Length == 0) return;

        int randomIndex = Random.Range(0, itemPrefabs.Length);
        float randomX = Random.Range(-spawnXRange, spawnXRange);
        Vector2 spawnPos = new Vector2(randomX, spawnY);
        Instantiate(itemPrefabs[randomIndex], spawnPos, Quaternion.identity);
    }
}
