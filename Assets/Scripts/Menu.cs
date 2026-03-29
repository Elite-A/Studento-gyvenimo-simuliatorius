using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Menu : MonoBehaviour
{
   public VideoPlayer currentScene;
    public VideoPlayer walkIn;
    public GameObject Studentauti;

 

    public void LoadOpeningScene()
    {
        currentScene.Stop();
        Studentauti.SetActive(false);

   
        walkIn.Play();

        
           walkIn.loopPointReached+= OnWalkInFinished;
    }
    
    private void OnWalkInFinished(VideoPlayer player)
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }

    public void Quit()
    {
        Application.Quit();
    }

}
