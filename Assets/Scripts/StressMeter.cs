using UnityEngine;
using UnityEngine.UI;

public class StressMeter : MonoBehaviour {
    public GameOver gameOver;
    public Text stressOutput;
    private double stressMeter=0;
    public int changeSpeed=50;

    public void IncreaseStress()
    {

        if (stressMeter >= 100)
            gameOver.Death();
        else
            stressMeter += changeSpeed * Time.deltaTime;
        stressOutput.text = "Stresas: " + ((int)stressMeter).ToString();
    }
    public void DecreaseStress()
    {

        if (stressMeter >= 0)
            stressMeter -= changeSpeed * Time.deltaTime;
        stressOutput.text = "Stresas: " + ((int)stressMeter).ToString();
    }


}