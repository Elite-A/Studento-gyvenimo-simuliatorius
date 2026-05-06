using UnityEngine;
using UnityEngine.Video;

public class DeathSceneController : MonoBehaviour
{
    public VideoPlayer cutscene;
    public GameObject ui;

    void Start()
    {
        ui.SetActive(false);

        cutscene.loopPointReached += OnVideoFinished;
        cutscene.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        ui.SetActive(true);
    }
}