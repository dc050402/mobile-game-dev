
using UnityEngine;

public class EnvironmentScroller : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float groundWidth = 20f;

    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (transform.position.x <= -groundWidth)
        {
            transform.position += Vector3.right * groundWidth * 2f;
        }
    }
}
