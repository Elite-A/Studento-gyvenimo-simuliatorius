using UnityEngine;
using TMPro;

public class BasketballMinigameManager : MonoBehaviour
{
    public static BasketballMinigameManager Instance;

    [Header("Game Settings")]
    public float gameDuration = 60f;
    private float currentTime;
    private bool gameActive;

    [Header("Score")]
    public int score;

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
        Instance = this;
    }

    private void Start()
    {
        if (basketball != null)
            ballRb = basketball.GetComponent<Rigidbody>();

        if (pressEText != null) pressEText.SetActive(false);
        if (minigameUI != null) minigameUI.SetActive(false);

        UpdateUI();
        basketball.SetActive(false); // ?? pradžioj pasl?ptas
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

        if (minigameUI != null) minigameUI.SetActive(true);
        if (pressEText != null) pressEText.SetActive(false);

        basketball.SetActive(true); // ?? ?JUNGIA kamuol?
        ResetBall();
    }

    public void EndGame()
    {
        gameActive = false;

        if (minigameUI != null) minigameUI.SetActive(false);

        ResetBall();
        Debug.Log("Game over. Final score: " + score);
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

    public bool IsGameActive()
    {
        return gameActive;
    }

    public void ShowInteractText(bool show)
    {
        Debug.Log("UI SET: " + show);

        if (pressEText != null)
            pressEText.SetActive(show);
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(currentTime);
    }
}