using UnityEngine;

public class GoldenAppleCollect : MonoBehaviour
{
    public AudioClip collectSound;
    public GameObject collectEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AppleCounter.Instance.AddScore(5);

            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            Instantiate(collectEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
