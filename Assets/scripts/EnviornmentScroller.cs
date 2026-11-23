
using UnityEngine;

public class EnvironmentScroller : MonoBehaviour
{
    public float scrollSpeed = 5f;

    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
    }
}
