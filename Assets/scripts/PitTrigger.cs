
using UnityEngine;

public class PitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("PLAYER ENTERED PIT");
        }
    }
}
