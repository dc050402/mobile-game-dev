
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public float minSpawnTime = 2f;
    public float maxSpawnTime = 4f;

    private float timer;
    private float nextSpawnTime;

    void Start()
    {
        SetNextSpawnTime();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            SpawnObstacle();
            timer = 0f;
            SetNextSpawnTime();
        }
    }

    void SpawnObstacle()
    {
        Instantiate(
            obstaclePrefab,
            transform.position,
            Quaternion.identity
        );
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
