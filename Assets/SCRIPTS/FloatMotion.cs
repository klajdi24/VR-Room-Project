using UnityEngine;

public class FloatMotion : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float floatHeight = 0.05f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = startPos + new Vector3(0, newY, 0);
    }
}
