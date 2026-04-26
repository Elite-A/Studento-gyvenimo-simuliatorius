using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    public GameObject  Player;

   
    public StressMeter stressMeter;
    public WaterMeter waterMeter;
    private int smokingBreaks;

    private bool isOutside = false;
    private bool nearFreshSpot = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Outside"))
            isOutside = true;
        if (other.CompareTag("Water"))
            nearFreshSpot = true;
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
        if (Input.GetKey(KeyCode.P))
            SceneManager.LoadScene("Pause");
        if (isOutside && Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Èiuvelis lauke");
           
                smokingBreaks++;

                stressMeter.DecreaseStress();
                if (smokingBreaks >=20)
                    SceneManager.LoadScene("Death");
            
        }
        if (nearFreshSpot && Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Geria");
            
                smokingBreaks++;

                waterMeter.IncreaseWater();
               
            
        }
    }
}

