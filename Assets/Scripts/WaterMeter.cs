using UnityEngine;
using UnityEngine.UI;


public class WaterMeter: MonoBehaviour
{
    public GameOver gameOver;
    public Text waterOutput;
    private double waterMeter = 50;
    public int changeSpeed = 1;

    private void Update()
    {
        if (waterMeter <= 0)
            gameOver.Death();
        else
            waterMeter -= (changeSpeed * Time.deltaTime)/3;
        waterOutput.text = "Vanduo: " + ((int)waterMeter).ToString();
    }
    public void IncreaseWater()
    {

        if (waterMeter >= 100)
            gameOver.Death();
        else
            waterMeter += changeSpeed * Time.deltaTime;
        waterOutput.text = "Vanduo: " + ((int)waterMeter).ToString();
    }
}
