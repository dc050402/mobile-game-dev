
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public GameObject orbPrefab;

    public float minSpawnTime = 2f;
    public float maxSpawnTime = 4f;

    public float minSpawnHeight = -1.5f;
    public float maxSpawnHeight = 0f;

    public float scrollSpeed = 5f;

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
        float randomY = Random.Range(minSpawnHeight, maxSpawnHeight);

        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            randomY,
            transform.position.z
        );

        GameObject orb = Instantiate(
            orbPrefab,
            spawnPosition,
            Quaternion.identity
        );

        GroundSectionMovement movement =
            orb.GetComponent<GroundSectionMovement>();

        if (movement == null)
        {
            movement = orb.AddComponent<GroundSectionMovement>();
        }

        movement.speed = scrollSpeed;
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
