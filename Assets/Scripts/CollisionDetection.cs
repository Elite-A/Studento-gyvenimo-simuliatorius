using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject  Player;

   
    public StressMeter stressMeter;
    public WaterMeter waterMeter;


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
                stressMeter.DecreaseStress();
            }
        }
    }
}
