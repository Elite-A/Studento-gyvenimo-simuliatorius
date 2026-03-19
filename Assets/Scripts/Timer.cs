using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameOver gameOver;
    public Text timeOutput;
    public float time = 60;
 

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeOutput.text = "Laikas iki paskaitos: " + ((int)time).ToString();
        if(time<=1)
            gameOver.Death();

    }

}
