using UnityEngine;
using UnityEngine.EventSystems;

public class FancyButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public float hoverScale = 1.10f;
    public float speed = 8f;

    public float idleRotation = 2f;
    public float idleSpeed = 2f;

    public AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    private Vector3 targetScale;
    private Quaternion startRotation;
    private bool hovering;

    void Start()
    {
        targetScale = Vector3.one;
        startRotation = transform.localRotation;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            Time.deltaTime * speed);

        if (!hovering)
        {
            float angle = Mathf.Sin(Time.time * idleSpeed) * idleRotation;
            transform.localRotation = startRotation * Quaternion.Euler(0, 0, angle);
        }
        else
        {
            transform.localRotation = Quaternion.Lerp(
                transform.localRotation,
                startRotation,
                Time.deltaTime * speed);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
        targetScale = Vector3.one * hoverScale;

        if (audioSource && hoverSound)
            audioSource.PlayOneShot(hoverSound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
        targetScale = Vector3.one;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (audioSource && clickSound)
            audioSource.PlayOneShot(clickSound);
    }
}