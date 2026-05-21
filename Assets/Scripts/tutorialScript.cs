using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialPopup : MonoBehaviour
{
    public GameObject tutorialPanel;
    public TMP_Text tutorialText;
    public float timePerLine = 2.5f;

    private void Start()
    {
        StartCoroutine(ShowTutorialLines());
    }

    private IEnumerator ShowTutorialLines()
    {
        tutorialPanel.SetActive(true);

        tutorialText.text = "Use WASD to move around!";
        yield return new WaitForSeconds(timePerLine);

        tutorialText.text = "Press G to take a drink when you're thirsty.";
        yield return new WaitForSeconds(timePerLine);

        tutorialText.text = "Press R to blow bubbles. Very productive, obviously.";
        yield return new WaitForSeconds(timePerLine);

        tutorialText.text = "Press E to play basketball.";
        yield return new WaitForSeconds(timePerLine);

        tutorialText.text = "Press F to enter buildings and rooms.";
        yield return new WaitForSeconds(timePerLine);

        tutorialPanel.SetActive(false);
    }
}