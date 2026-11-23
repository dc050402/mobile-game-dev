
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject groundPrefab;
    public float sectionWidth = 1.5f;
    public float scrollSpeed = 5f;

    public float groundWidth = 3f;
    public float gapWidth = 0.8f;

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
        nextSpawnX -= scrollSpeed * Time.deltaTime;

        if (nextSpawnX < 40f)
        {
            SpawnGround(Random.Range(0, 3) == 0);
        }
    }

    void SpawnGround(bool makeGap)
    {
        if (makeGap)
        {
            nextSpawnX += gapWidth;
        }
        else
        {
            GameObject ground = Instantiate(
                groundPrefab,
                new Vector3(nextSpawnX + groundWidth / 2f, -3f, 0f),
                Quaternion.identity
            );

            ground.transform.localScale = new Vector3(groundWidth, 1f, 1f);
            ground.AddComponent<GroundSectionMovement>().speed = scrollSpeed;

            nextSpawnX += groundWidth;
        }
    }
}
