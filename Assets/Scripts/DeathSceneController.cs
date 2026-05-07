using UnityEngine;
using UnityEngine.Video;

public class DeathSceneController : MonoBehaviour
{
    public VideoPlayer cutscene;
    public VideoClip[] deathClips;
    public GameObject ui;

    void Start()
    {
        ui.SetActive(false);

        int index = Mathf.Clamp(DeathReason.reason, 0, deathClips.Length - 1);

        cutscene.clip = deathClips[index];

        cutscene.loopPointReached += OnVideoFinished;

        cutscene.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        ui.SetActive(true);
    }
}