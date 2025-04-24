using UnityEngine;
using UnityEngine.UI; // Required for Button
using TMPro; // Required for TextMeshProUGUI

public class ChessUIManager : MonoBehaviour
{
    public TextMeshProUGUI messageText; // TextMeshProUGUI text to display the message
    public Button tryAgainButton; // Button for retrying
    public Button exitButton; // Button for exiting

    void Start()
    {
        tryAgainButton.gameObject.SetActive(false); // Hide buttons initially
        exitButton.gameObject.SetActive(false); // Hide buttons initially
        gameObject.SetActive(false); // Hide the Canvas initially
        Debug.Log("ChessUIManager with TMP initialized.");
    }

    // Show the message with optional buttons
    public void ShowMessage(string text, bool showButtons = false)
    {
        messageText.text = text; // Set the message text
        tryAgainButton.gameObject.SetActive(showButtons); // Show/hide the Try Again button
        exitButton.gameObject.SetActive(showButtons); // Show/hide the Exit button
        gameObject.SetActive(true); // Show the UI Canvas
    }

    // Hide the message and buttons
    public void HideMessage()
    {
        gameObject.SetActive(false); // Hide the UI Canvas
    }

    // Handle the Try Again button press
    public void OnTryAgainPressed()
    {
        Debug.Log("Try Again Pressed");
        HideMessage(); // Hide the message UI
    }

    // Handle the Exit button press
    public void OnExitPressed()
    {
        Debug.Log("Exit Pressed");
        HideMessage(); // Hide the message UI
        // Optionally, you can handle additional logic here (e.g., return to main menu)
    }
}
