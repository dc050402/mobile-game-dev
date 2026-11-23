
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public float minSpawnTime = 2f;
    public float maxSpawnTime = 4f;

    public float groundCheckDistance = 2f;
    public float safeGroundWidth = 3f;

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
            if (HasSafeGround())
            {
                SpawnObstacle();
            }

            timer = 0f;
            SetNextSpawnTime();
        }
    }

    bool HasSafeGround()
    {
        float halfWidth = safeGroundWidth / 2f;

        Vector2 leftCheck = new Vector2(
            transform.position.x - halfWidth,
            transform.position.y - 1f
        );

        Vector2 rightCheck = new Vector2(
            transform.position.x + halfWidth,
            transform.position.y - 1f
        );

        RaycastHit2D leftHit = Physics2D.Raycast(
            leftCheck, Vector2.down, groundCheckDistance
        );

        RaycastHit2D rightHit = Physics2D.Raycast(
            rightCheck, Vector2.down, groundCheckDistance
        );

        return leftHit.collider != null &&
               rightHit.collider != null &&
               leftHit.collider.CompareTag("Ground") &&
               rightHit.collider.CompareTag("Ground");
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
