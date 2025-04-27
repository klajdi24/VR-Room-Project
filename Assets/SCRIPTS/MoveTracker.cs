using UnityEngine;

public class MoveTracker : MonoBehaviour
{
    public Transform winningSquare; // Existing reference for trigger zone
    public Transform winningAnchor; // NEW reference for snapping queen

    public GameObject winText;
    public GameObject wrongText;

    public void ShowWin()
    {
        if (winText != null) winText.SetActive(true);
        if (wrongText != null) wrongText.SetActive(false);
    }

    public void ShowWrong()
    {
        if (wrongText != null) wrongText.SetActive(true);
        if (winText != null) winText.SetActive(false);
    }

    public void HideAll()
    {
        if (winText != null) winText.SetActive(false);
        if (wrongText != null) wrongText.SetActive(false);
    }
}
