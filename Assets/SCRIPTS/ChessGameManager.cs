using UnityEngine;
using UnityEngine.UI; // For Button support
using TMPro; // For TextMeshPro

public class ChessGameManager : MonoBehaviour
{
    public Canvas messageCanvas; // Reference to the UI Canvas
    public TextMeshProUGUI messageText; // Message text
    public Button tryAgainButton; // Try Again button
    public Button exitButton; // Exit button

    // Show a message and optionally display buttons
    public void ShowMessage(string message, bool showButtons = false)
    {
        if (messageCanvas == null || messageText == null || tryAgainButton == null || exitButton == null)
        {
            Debug.LogError("ChessGameManager: Missing UI references.");
            return;
        }

        messageCanvas.gameObject.SetActive(true); // Show canvas
        messageText.text = message; // Set text
        tryAgainButton.gameObject.SetActive(showButtons); // Toggle buttons
        exitButton.gameObject.SetActive(showButtons);
    }

    // Hide everything
    public void HideMessage()
    {
        if (messageCanvas != null)
            messageCanvas.gameObject.SetActive(false);
    }
}
