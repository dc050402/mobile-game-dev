
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public GameObject orbPrefab;

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
            SpawnOrb();
            timer = 0f;
            SetNextSpawnTime();
        }
    }

    void SpawnOrb()
    {
        Instantiate(orbPrefab, transform.position, Quaternion.identity);
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
