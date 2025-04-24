using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Use this for TextMeshProUGUI

public class ChessMoveValidator : MonoBehaviour
{
    public string finalMove = "e7e8Q"; // Example: pawn to promotion
    public Canvas messageCanvas;  // Reference to the Canvas that holds the message UI
    public TextMeshProUGUI messageText;  // Reference to the TextMeshProUGUI component for messages

    // Call this method when the player makes a move
    public void OnPlayerMove(string move)
    {
        if (move == finalMove)
        {
            ShowMessage("You won!");
            // Additional victory logic here
        }
        else
        {
            ShowMessage("Not the final move. Try again or exit.");
        }
    }

    // Show the message
    void ShowMessage(string text)
    {
        messageCanvas.gameObject.SetActive(true);  // Activate the canvas
        messageText.text = text;  // Update the TextMeshProUGUI text
    }
}
