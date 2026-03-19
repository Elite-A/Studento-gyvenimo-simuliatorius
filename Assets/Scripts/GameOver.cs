using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverPicture;
    public MouseMovement mouseMovement;
    public void Death()
    {
        mouseMovement.Disable();
        GameOverPicture.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
