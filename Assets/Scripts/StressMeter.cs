using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StressMeter : MonoBehaviour {
    public Text stressOutput;
    private double stressMeter=0;
    public int changeSpeed=50;

    public void IncreaseStress()
    {

        if (stressMeter >= 100)
            SceneManager.LoadScene("Death");
        else
            stressMeter += changeSpeed * Time.deltaTime;
        stressOutput.text = "Stresas: " + ((int)stressMeter).ToString();
    }
    public void DecreaseStress()
    {

        if (stressMeter >= 20)
            stressMeter -= 20;
        else
            stressMeter = 0;
            stressOutput.text = "Stresas: " + ((int)stressMeter).ToString();
    }


}