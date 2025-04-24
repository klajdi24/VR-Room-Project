using UnityEngine;
using UnityEngine.UI;
using TMPro; // <-- Required for TextMeshProUGUI

public class ChessUIManager : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Button tryAgainButton;
    public Button exitButton;

    void Start()
    {
        tryAgainButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
        Debug.Log("ChessUIManager with TMP initialized.");
    }

    public void ShowMessage(string text, bool showButtons = false)
    {
        messageText.text = text;
        tryAgainButton.gameObject.SetActive(showButtons);
        exitButton.gameObject.SetActive(showButtons);
        gameObject.SetActive(true);
    }

    public void HideMessage()
    {
        gameObject.SetActive(false);
    }

    public void OnTryAgainPressed()
    {
        Debug.Log("Try Again Pressed");
        HideMessage();
    }

    public void OnExitPressed()
    {
        Debug.Log("Exit Pressed");
        HideMessage();
    }
}
