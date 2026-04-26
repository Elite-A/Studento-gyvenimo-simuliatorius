using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    public GameObject  Player;

   
    public StressMeter stressMeter;
    public WaterMeter waterMeter;
    private int smokingBreaks;

    private bool isOutside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Outside"))
            isOutside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Outside"))
            isOutside = false;
    }

    private void OnTriggerStay(Collider other)
    {
    
        if (other.CompareTag("NPC"))
        {
            Debug.Log("trigerinasi su NPC");
            stressMeter.IncreaseStress();   
        }

        if (other.CompareTag("Water"))
        {
            Debug.Log("trigerinasi su Vandeniu");
            waterMeter.IncreaseWater();

        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.P))
            SceneManager.LoadScene("Pause");
        if (isOutside && Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Èiuvelis lauke");
            if (Input.GetKey(KeyCode.K))
            {
                smokingBreaks++;

                stressMeter.DecreaseStress();
                if (smokingBreaks >=20)
                    SceneManager.LoadScene("Death");
            }
        }
    }
}

