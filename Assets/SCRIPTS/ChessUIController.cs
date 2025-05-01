using UnityEngine;
using TMPro;

public class ChessUIController : MonoBehaviour
{
    public Canvas messageCanvas; // Reference to the UI Canvas
    public TextMeshProUGUI messageText; // Message display

    private void Start()
    {
        HideMessage();
    }

    // Show a message on screen
    public void ShowMessage(string message)
    {
        if (messageCanvas == null || messageText == null)
        {
            Debug.LogError("ChessUIController: Canvas or Text is not assigned.");
            return;
        }

        messageText.text = message;
        messageCanvas.gameObject.SetActive(true);
    }

    // Hide the message
    public void HideMessage()
    {
        if (messageCanvas != null)
            messageCanvas.gameObject.SetActive(false);
    }
}
