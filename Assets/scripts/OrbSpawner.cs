
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
        GameObject orb = Instantiate(
            orbPrefab,
            transform.position,
            Quaternion.identity
        );

        orb.AddComponent<GroundSectionMovement>().speed = 5f;
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }


}
