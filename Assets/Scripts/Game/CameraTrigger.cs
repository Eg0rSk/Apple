using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Transform player;
    public Transform targetObject;

    public float smoothSpeed = 5f;
    public float triggerDistance = 5f;
    public float autoZoom = 3f;

    public float minDistance = 4f;
    public float maxDistance = 12f;
    public float zoomSpeed = 5f;

    private Vector3 startOffset;
    private Vector3 currentOffset;
    private Quaternion startRotation;

    private float currentDistance;

    void Start()
    {
        startOffset = transform.position - player.position;
        currentOffset = startOffset;

        currentDistance = startOffset.magnitude;

        startRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Зум колесиком
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            currentDistance -= scroll * zoomSpeed;
            currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);
        }

        // Якщо біля куба — тимчасово віддаляємо
        float targetDistance = currentDistance;

        if (Vector3.Distance(player.position, targetObject.position) <= triggerDistance)
        {
            targetDistance += autoZoom;
        }

        Vector3 targetOffset = startOffset.normalized * targetDistance;
        targetOffset.y = startOffset.y;

        currentOffset = Vector3.Lerp(currentOffset, targetOffset, smoothSpeed * Time.deltaTime);

        transform.position = player.TransformPoint(currentOffset);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(
                startRotation.eulerAngles.x,
                player.eulerAngles.y,
                startRotation.eulerAngles.z),
            smoothSpeed * Time.deltaTime);
    }
}
