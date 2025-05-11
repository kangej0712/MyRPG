using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float startPosX;
    public Transform cam;
    public float parallaxFactor;

    void Start()
    {
        startPosX = transform.position.x;
    }

    void Update()
    {
        float dist = cam.position.x * parallaxFactor;
        transform.position = new Vector3(startPosX + dist, transform.position.y, transform.position.z);
    }
}
