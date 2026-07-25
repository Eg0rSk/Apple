using UnityEngine;

public class AppleFloat : MonoBehaviour
{
    public float height = 10f;
    public float speed = 2f;

    private Vector3 startPos;
    private float offset;

    void Start()
    {
        startPos = transform.localPosition;
        offset = Random.Range(0f, 10f);
    }

    void Update()
    {
        transform.localPosition =
            startPos +
            Vector3.up * Mathf.Sin((Time.time + offset) * speed) * height;
    }
}
