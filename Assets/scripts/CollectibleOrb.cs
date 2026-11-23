
using UnityEngine;

public class CollectibleOrb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<GameManager>().AddScore(10);

            Destroy(gameObject);
        }
    }
}
