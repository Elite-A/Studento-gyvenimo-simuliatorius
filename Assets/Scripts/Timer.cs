using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
 
    public Text timeOutput;
    public float time = 60;
 

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeOutput.text = "Laikas iki paskaitos: " + ((int)time).ToString();
        if(time<=15)
        {
            timeOutput.color = Color.red;
            timeOutput.fontSize = 24;
            timeOutput.text = "TURI PASIEKTI KLASE PER: " + ((int)time).ToString();

            if (time < 1)
            {
                DeathReason.reason = 0;
                SceneManager.LoadScene("Death");
            }
        }

        

    }

}
