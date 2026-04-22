using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public VideoPlayer menuLoopVideo;
    public VideoPlayer introVideo;

    public GameObject menuPanel;
    public GameObject introPanel;

    public GameObject buttonsPanel;
    public GameObject logo;

    public Image fadeImage;
    public float fadeDuration = 1f;

    void Start()
    {
        // Start looping menu video
        menuLoopVideo.isLooping = true;
        menuLoopVideo.Play();

        // Hide intro at start
        introVideo.gameObject.SetActive(false);
        introPanel.SetActive(false);

        // Make sure screen is visible (no fade)
        SetFadeAlpha(0f);

        // Subscribe to video end event
        introVideo.loopPointReached += HandleIntroFinished;
    }

    public void StartGame()
    {
        // Stop and hide menu
        menuLoopVideo.Stop();
        menuLoopVideo.gameObject.SetActive(false);
        logo.gameObject.SetActive(false);
        menuPanel.SetActive(false);
        buttonsPanel.SetActive(false);

        // Show intro
        introVideo.gameObject.SetActive(true);
        introPanel.SetActive(true);

        // Play intro safely (next frame to avoid Unity bugs)
        StartCoroutine(PlayIntroNextFrame());
    }

    IEnumerator PlayIntroNextFrame()
    {
        yield return null; // wait 1 frame
        introVideo.Play();
    }

    void HandleIntroFinished(VideoPlayer vp)
    {
        // Video FULLY finished → NOW fade
        StartCoroutine(FadeToBlack());
    }

    IEnumerator FadeToBlack()
    {
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            SetFadeAlpha(alpha);
            yield return null;
        }

        SetFadeAlpha(1f);

        // Start your game here
        Debug.Log("Game starts now");
        // SceneManager.LoadScene("GameScene");
    }

    void SetFadeAlpha(float alpha)
    {
        Color c = fadeImage.color;
        c.a = alpha;
        fadeImage.color = c;
    }

    
}