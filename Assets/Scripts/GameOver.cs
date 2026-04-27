using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.ComponentModel.Design;
using System.Xml.Linq;

public class GameOver : MonoBehaviour
{
    public TMP_Text deathText;
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void Start()
    {
        deathText.text = DeathReason.reason;
    }

}
