using UnityEngine;
using TMPro; // Required for TextMeshProUGUI

public class ChessMoveValidator : MonoBehaviour
{
    public string finalMove = "e7e8Q"; // Example: the final move to win
   // public ChessGameManager gameManager; // Reference to the ChessGameManager

    // Call this method when the player makes a move
    public void OnPlayerMove(string move)
    {
        if (move == finalMove)
        {
            //gameManager.ShowMessage("You won!", true); // Show message if it's the final move
        }
        else
        {
           // gameManager.ShowMessage("Not the final move. Try again or exit.", true); // Show a different message if not the final move
        }
    }
}
