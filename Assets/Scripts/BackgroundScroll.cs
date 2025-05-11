using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float backgroundWidth = 20f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, backgroundWidth);
        transform.position = startPos + Vector3.left * newPos;
    }
}
