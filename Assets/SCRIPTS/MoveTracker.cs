using UnityEngine;
using System.Collections;

public class MoveTracker : MonoBehaviour
{
    public Transform winningSquare;
    public Transform winningAnchor;

    public GameObject winText;
    public GameObject wrongText;
    public GameObject initialText;

    public ParticleSystem winParticles;
    public AudioSource winSound;
    public AudioSource wrongSound; // ✅ New!

    private Coroutine wrongCoroutine;

    public void ShowWin()
    {
        if (wrongCoroutine != null)
            StopCoroutine(wrongCoroutine);

        HideAll();
        if (winText != null) winText.SetActive(true);
        if (initialText != null) initialText.SetActive(false);

        if (winParticles != null)
        {
            winParticles.Play();
            StartCoroutine(StopParticlesAfterDelay());
        }

        if (winSound != null)
        {
            winSound.Play();
        }
    }

    private IEnumerator StopParticlesAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        if (winParticles != null)
        {
            winParticles.Stop();
        }
    }

    public void ShowWrong()
    {
        if (wrongCoroutine != null)
            StopCoroutine(wrongCoroutine);

        HideAll();
        if (wrongText != null) wrongText.SetActive(true);
        if (initialText != null) initialText.SetActive(false);

        if (wrongSound != null)
        {
            wrongSound.Play(); // ✅ Play wrong sound here
        }

        wrongCoroutine = StartCoroutine(HideWrongAfterDelay());
    }

    private IEnumerator HideWrongAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        if (wrongText != null) wrongText.SetActive(false);
        if (initialText != null) initialText.SetActive(true);
    }

    public void HideAll()
    {
        if (winText != null) winText.SetActive(false);
        if (wrongText != null) wrongText.SetActive(false);
        if (initialText != null) initialText.SetActive(false);
    }
}
