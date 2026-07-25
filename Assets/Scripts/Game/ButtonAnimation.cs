using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonAnimation : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    [Header("Animation")]
    public float hoverScale = 1.1f;
    public float floatHeight = 5f;
    public float floatSpeed = 2f;

    private RectTransform rect;
    private Vector3 startScale;
    private Vector2 startPos;

    private bool hovering;

    void Start()
    {
        rect = GetComponent<RectTransform>();

        startScale = rect.localScale;
        startPos = rect.anchoredPosition;
    }

    void Update()
    {
        if (!hovering)
        {
            rect.anchoredPosition =
                startPos +
                Vector2.up * Mathf.Sin(Time.unscaledTime * floatSpeed) * floatHeight;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;

        if (audioSource && hoverSound)
            audioSource.PlayOneShot(hoverSound);

        StopAllCoroutines();
        StartCoroutine(ScaleTo(startScale * hoverScale));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;

        StopAllCoroutines();
        StartCoroutine(ScaleTo(startScale));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (audioSource && clickSound)
            audioSource.PlayOneShot(clickSound);

        StopAllCoroutines();
        StartCoroutine(ClickAnimation());
    }

    IEnumerator ScaleTo(Vector3 target)
    {
        while (Vector3.Distance(rect.localScale, target) > 0.01f)
        {
            rect.localScale = Vector3.Lerp(rect.localScale, target, Time.unscaledDeltaTime * 12f);
            yield return null;
        }

        rect.localScale = target;
    }

    IEnumerator ClickAnimation()
    {
        rect.localScale = startScale * 0.9f;

        yield return new WaitForSecondsRealtime(0.08f);

        rect.localScale = hovering ? startScale * hoverScale : startScale;
    }
}