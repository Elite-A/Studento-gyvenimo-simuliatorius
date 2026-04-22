using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    public GameObject  Player;

   
    public StressMeter stressMeter;
    public WaterMeter waterMeter;
    private int smokingBreaks;


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

        if (other.CompareTag("Outside"))
        {
            Debug.Log("Èiuvelis lauke");
            if (Input.GetKey(KeyCode.K))
            {
                smokingBreaks++;

                stressMeter.DecreaseStress();
                if (smokingBreaks == 100)
                    SceneManager.LoadScene("Death");
            }
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.P))
            SceneManager.LoadScene("Pause");
    }
}
