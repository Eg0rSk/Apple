using TMPro;
using UnityEngine;

public class AppleCounter : MonoBehaviour
{
    public static AppleCounter Instance;

    public TextMeshProUGUI appleText;
    public GameObject winPanel;

    private int score = 0;
    private int totalApples;
    private int applesCollected = 0;
    
    public AudioClip winSound;
    public AudioSource audioSource;
    public AudioSource musicSource;
    
    public CharacterController playerController;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        totalApples = FindObjectsByType<AppleCollect>(FindObjectsSortMode.None).Length;

        winPanel.SetActive(false);
        UpdateText();
    }

    public void AddScore(int points)
    {
        score += points;
        applesCollected++;

        UpdateText();

        if (applesCollected >= totalApples)
        {
            appleText.gameObject.SetActive(false);
            
            musicSource.Stop();
            
            playerController.DisableFootsteps();

            audioSource.PlayOneShot(winSound); // ← ось цей рядок додай

            winPanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    void UpdateText()
    {
        appleText.text = $"Score: {score}";
    }
    public void UpdateTotalApples()
    {
        totalApples = FindObjectsByType<AppleCollect>(FindObjectsSortMode.None).Length;
        UpdateText();
    }
}
