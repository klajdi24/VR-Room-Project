using UnityEngine;
using TMPro;  // Use this namespace for TextMeshPro components

public class ChessGameManager : MonoBehaviour
{
    // The final move for winning the game, e.g., "e7e8Q" for a pawn promoting to a queen
    public string finalMove = "e7e8Q"; 
    
    // Canvas that will show the message
    public Canvas messageCanvas;  
    
    // Reference to the TextMeshProUGUI for showing the message
    public TextMeshProUGUI messageText;  

    // This function is called when the player makes a move
    public void OnPlayerMove(string move)
    {
        if (move == finalMove)
        {
            // If the player made the final move, show the "You won!" message
            ShowMessage("You won!");
        }
        else
        {
            // If the move isn't the final one, ask the player to try again
            ShowMessage("Not the final move. Try again or exit.");
        }
    }

    // This function shows a message on the canvas
    void ShowMessage(string text)
    {
        messageCanvas.gameObject.SetActive(true);  // Activate the message canvas
        messageText.text = text;  // Update the message text with the new string
    }
}
