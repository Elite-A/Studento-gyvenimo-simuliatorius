using UnityEngine;

public class NPCVoiceLine : MonoBehaviour
{
    public AudioClip[] voiceLines;
    public float cooldown = 8f;

    [Range(0f, 100f)]
    public float chancePercent = 50f;

    public float maxHearDistance = 15f;

    private AudioSource audioSource;
    private float lastPlayTime = -999f;
    private bool hasSpoken = false; // ← NAUJA

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.spatialBlend = 1f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.minDistance = 2f;
        audioSource.maxDistance = maxHearDistance;
    }

    public void PlayVoiceLine()
    {
        if (hasSpoken) return; // ← NAUJA
        if (voiceLines.Length == 0) return;
        if (Time.time - lastPlayTime < cooldown) return;

        if (Random.Range(0f, 100f) > chancePercent) return;

        AudioClip clip = voiceLines[Random.Range(0, voiceLines.Length)];
        audioSource.PlayOneShot(clip);
        lastPlayTime = Time.time;
        hasSpoken = true; // ← NAUJA
    }
}