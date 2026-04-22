using UnityEngine;

public class MinigameInteract : MonoBehaviour
{
    private bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered: " + other.name + " tag: " + other.tag);

        if (other.CompareTag("Player") && BasketballMinigameManager.Instance.IsGameActive() == false)
        {
            playerInside = true;
            Debug.Log("Player entered zone");
            BasketballMinigameManager.Instance.ShowInteractText(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && BasketballMinigameManager.Instance.IsGameActive() == false)
        {
            playerInside = false;
            Debug.Log("Player left zone");
            BasketballMinigameManager.Instance.ShowInteractText(false);
        }
    }

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E) && BasketballMinigameManager.Instance.IsGameActive()==false)
        {
            Debug.Log("Starting minigame");
            BasketballMinigameManager.Instance.StartGame();
        }
    }
}