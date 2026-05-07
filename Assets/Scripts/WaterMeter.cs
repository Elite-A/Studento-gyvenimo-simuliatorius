using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WaterMeter: MonoBehaviour
{
    public Text waterOutput;
    private double waterMeter = 50;
    public int changeSpeed = 1;

    private void Update()
    {
        if (waterMeter <= 0)
        {

            DeathReason.reason = 1;
            SceneManager.LoadScene("Death");
        }
        else
            waterMeter -= (changeSpeed * Time.deltaTime) / 3;
        waterOutput.text = "Vanduo: " + ((int)waterMeter).ToString();
    }
    public void IncreaseWater()
    {

        if (waterMeter >= 80)
        {
            DeathReason.reason = 2;
            SceneManager.LoadScene("Death");
        }

        else

            waterMeter += 20;
        waterOutput.text = "Vanduo: " + ((int)waterMeter).ToString();
    }
}
