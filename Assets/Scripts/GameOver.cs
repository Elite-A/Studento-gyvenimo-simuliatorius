using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver:MonoBehaviour
{
    public GameObject GameOverPicture;
    public void Death()
    {
        GameOverPicture.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    
}
