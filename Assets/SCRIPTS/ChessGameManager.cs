using UnityEngine;
using UnityEngine.UI; // Make sure you have this for UI elements (Text, Buttons, etc.)
using TMPro; // For TextMeshPro

public class ChessGameManager : MonoBehaviour
{
    public Canvas messageCanvas; // Reference to the Canvas (UI element that holds the message)
    public TextMeshProUGUI messageText; // Reference to the TextMeshProUGUI text for the message
    public Button tryAgainButton; // Reference to the Try Again Button
    public Button exitButton; // Reference to the Exit Button

    // Show a message and optionally display buttons
    public void ShowMessage(string message, bool showButtons = false)
    {
        messageCanvas.gameObject.SetActive(true); // Show the Canvas
        messageText.text = message; // Update the message text

        tryAgainButton.gameObject.SetActive(showButtons); // Show/hide the Try Again button
        exitButton.gameObject.SetActive(showButtons); // Show/hide the Exit button
    }

    // Hide the message and buttons
    public void HideMessage()
    {
        messageCanvas.gameObject.SetActive(false); // Hide the entire UI
    }
}
