using UnityEngine;
using TMPro;

public class BasketballMinigameManager : MonoBehaviour
{
    public static BasketballMinigameManager Instance;

    [Header("Game Settings")]
    public float gameDuration = 60f;
    private float currentTime;
    private bool gameActive = false;

    [Header("Score")]
    public int score = 0;

    [Header("References")]
    public GameObject basketball;
    public Transform ballSpawnPoint;

    [Header("UI")]
    public GameObject pressEText;
    public GameObject minigameUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    private Rigidbody ballRb;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (basketball != null)
        {
            ballRb = basketball.GetComponent<Rigidbody>();
            basketball.SetActive(false);
        }

        if (pressEText != null) pressEText.SetActive(false);
        if (minigameUI != null) minigameUI.SetActive(false);

        UpdateUI();
    }

    private void Update()
    {
        if (!gameActive) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            EndGame();
        }

        UpdateUI();
    }

    public void StartGame()
    {
        gameActive = true;
        score = 0;
        currentTime = gameDuration;

        if (pressEText != null) pressEText.SetActive(false);
        if (minigameUI != null) minigameUI.SetActive(true);

        if (basketball != null)
        {
            basketball.SetActive(true);
            ResetBall();
        }

        UpdateUI();
    }

    public void EndGame()
    {
        gameActive = false;

        if (minigameUI != null) minigameUI.SetActive(false);
        if (pressEText != null) pressEText.SetActive(false);

        if (basketball != null)
        {
            ResetBall();
            basketball.SetActive(false);
        }

        Debug.Log("Game over. Final score: " + score);
    }

    public bool IsGameActive()
    {
        return gameActive;
    }

    public void AddScore(int amount)
    {
        if (!gameActive) return;

        score += amount;
        UpdateUI();
    }

    public void ResetBall()
    {
        if (basketball == null || ballSpawnPoint == null) return;

        basketball.transform.position = ballSpawnPoint.position;
        basketball.transform.rotation = ballSpawnPoint.rotation;

        if (ballRb != null)
        {
            ballRb.linearVelocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
        }
    }

    public void ShowInteractText(bool show)
    {
        if (pressEText != null && !gameActive)
            pressEText.SetActive(show);
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(currentTime).ToString();
    }
}