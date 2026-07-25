using UnityEngine;

public class AppleAnimation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private float floatHeight = 0.25f;
    [SerializeField] private float floatSpeed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        Vector3 pos = startPos;
        pos.y += Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = pos;
    }
}
