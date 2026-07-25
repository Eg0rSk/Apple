using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject goldenApplePrefab;

    public int appleCount = 50;
    public int goldenAppleCount = 5;

    public Vector3 spawnArea = new Vector3(100f, 0f, 100f);

    void Start()
    {
        // Звичайні яблука
        for (int i = 0; i < appleCount; i++)
        {
            SpawnApple(applePrefab);
        }

        // Золоті яблука
        for (int i = 0; i < goldenAppleCount; i++)
        {
            SpawnApple(goldenApplePrefab);
        }

        AppleCounter.Instance.UpdateTotalApples();
    }

    void SpawnApple(GameObject prefab)
    {
        Vector3 randomPosition = transform.position + new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            0,
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );

        Instantiate(prefab, randomPosition, Quaternion.identity);
    }
}
