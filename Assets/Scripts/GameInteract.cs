using UnityEngine;

public class MinigameInteract : MonoBehaviour
{
    private bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !BasketballMinigameManager.Instance.IsGameActive())
        {
            playerInside = true;
            BasketballMinigameManager.Instance.ShowInteractText(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            BasketballMinigameManager.Instance.ShowInteractText(false);
        }
    }

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            if (!BasketballMinigameManager.Instance.IsGameActive())
            {
                BasketballMinigameManager.Instance.StartGame();
            }
        }
    }
}