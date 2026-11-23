
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject groundPrefab;
    public float sectionWidth = 2.5f;
    public float scrollSpeed = 5f;

    private float nextSpawnX = 0f;

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            SpawnGround(false);
        }
    }

    void Update()
    {
        if (nextSpawnX - transform.position.x < 40f)
        {
            SpawnGround(Random.Range(0, 3) == 0);
        }
    }

    void SpawnGround(bool makeGap)
    {
        if (!makeGap)
        {
            GameObject ground = Instantiate(
                groundPrefab,
                new Vector3(nextSpawnX + sectionWidth / 2f, -3f, 0f),
                Quaternion.identity
            );

            ground.transform.localScale = new Vector3(sectionWidth, 1f, 1f);
            ground.AddComponent<GroundSectionMovement>().speed = scrollSpeed;
        }

        nextSpawnX += sectionWidth;
    }
}
