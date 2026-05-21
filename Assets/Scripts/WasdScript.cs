using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialPopup : MonoBehaviour
{
    public GameObject tutorialPanel;
    public TMP_Text tutorialText;
    public float timePerLine =5f;

    private void Start()
    {
        StartCoroutine(ShowTutorialLines());
    }

    private IEnumerator ShowTutorialLines()
    {
        tutorialPanel.SetActive(true);

        tutorialText.text = "Naudok WASD judėti.";
        yield return new WaitForSeconds(timePerLine);

        tutorialText.text = "Spausk G Fresh Spot'e atsigerti";
        yield return new WaitForSeconds(timePerLine);

        tutorialText.text = "Spausk R pūsti burbulus vidiniame kiemelyje.";
        yield return new WaitForSeconds(timePerLine);

        tutorialText.text = "Spausk E, kad pradėtum krepšinio žaidimą.";
        yield return new WaitForSeconds(timePerLine);

        tutorialText.text = "Spausk F, kad patektum į auditoriją.";
        yield return new WaitForSeconds(timePerLine);

        tutorialPanel.SetActive(false);
    }
}