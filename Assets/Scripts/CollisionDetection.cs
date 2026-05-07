using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    public GameObject  Player;
    public GameObject PauseMenu;
    public MouseMovement mouseMovement;
    public Timer timer;

   
    public StressMeter stressMeter;
    public WaterMeter waterMeter;
    private int smokingBreaks;

    private bool isOutside = false;
    private bool nearFreshSpot = false;

    void Start()
    {

        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        mouseMovement.enabled = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Outside"))
            isOutside = true;
        if (other.CompareTag("Water"))
            nearFreshSpot = true;
        if (other.CompareTag("Classroom"))
        {
            if (timer.time > 0 && timer.time <= 15)
            {
                DeathReason.reason = 4;


                SceneManager.LoadScene("Death");
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Outside"))
            isOutside = false;
        if (other.CompareTag("Water"))
            nearFreshSpot = false;
    }

    private void OnTriggerStay(Collider other)
    {
    
        if (other.CompareTag("NPC"))
        {
            Debug.Log("trigerinasi su NPC");
            stressMeter.IncreaseStress();   
        }

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            bool isPaused = PauseMenu.activeSelf;

            if (isPaused)
            {
                // Atpausuojam
                PauseMenu.SetActive(false);
                Time.timeScale = 1f;
                mouseMovement.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                // Pausuojam
                PauseMenu.SetActive(true);
                Time.timeScale = 0f;
                mouseMovement.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        if (isOutside && Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Èiuvelis lauke");
           
                smokingBreaks++;

                stressMeter.DecreaseStress();
            if (smokingBreaks >= 20)
            {
                DeathReason.reason = 5;
                SceneManager.LoadScene("Death");
            }
            
        }
        if (nearFreshSpot && Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Geria");
            
                smokingBreaks++;

                waterMeter.IncreaseWater();
               
            
        }
    }
    public void Continue()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        mouseMovement.enabled = true;


    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

