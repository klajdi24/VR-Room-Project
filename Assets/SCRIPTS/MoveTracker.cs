using UnityEngine;
using System.Collections;

public class MoveTracker : MonoBehaviour
{
    public Transform winningSquare; // Existing
    public Transform winningAnchor; // Existing

    public GameObject winText;
    public GameObject wrongText;
    public GameObject initialText; // 👈 Add this (assign "Make the move" text here!)

    private Coroutine wrongCoroutine;

    public void ShowWin()
    {
        if (wrongCoroutine != null)
            StopCoroutine(wrongCoroutine);

        HideAll();
        if (winText != null) winText.SetActive(true);
        if (initialText != null) initialText.SetActive(false); // Hide initial text when winning
    }

    public void ShowWrong()
    {
        if (wrongCoroutine != null)
            StopCoroutine(wrongCoroutine);

        HideAll();
        if (wrongText != null) wrongText.SetActive(true);
        if (initialText != null) initialText.SetActive(false);

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
