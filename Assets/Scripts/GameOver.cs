using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.ComponentModel.Design;
using System.Xml.Linq;

public class GameOver : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
