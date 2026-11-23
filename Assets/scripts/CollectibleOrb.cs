
using UnityEngine;

public class CollectibleOrb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<GameManager>().AddScore(10);
            FindFirstObjectByType<GameManager>().AddZenEnergy(50);
            Destroy(gameObject);
        }
    }
}
