using UnityEngine;

public class AppleCollect : MonoBehaviour
{
    public AudioClip collectSound;
    public GameObject collectEffect;
    public int points = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AppleCounter.Instance.AddScore(points);

            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            Instantiate(collectEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
