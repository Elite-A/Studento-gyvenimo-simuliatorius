using UnityEngine;

public class HoopScore : MonoBehaviour
{
    private bool canScore = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!BasketballMinigameManager.Instance.IsGameActive()) return;

        if (other.CompareTag("Basketball"))
        {
            canScore = false;
            BasketballMinigameManager.Instance.AddScore(1);
        }
    }
}