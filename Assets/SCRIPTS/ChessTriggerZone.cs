using UnityEngine;

public class ChessTriggerZone : MonoBehaviour
{
    public ChessGameManager gameManager; // Reference to the ChessGameManager
    public string finalMoveMessage = "Make the final move to win!"; // Message shown when close to the chessboard

    // This method is called when the player enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object is tagged as "Player"
        {
            Debug.Log("Player entered the trigger zone!");
            gameManager.ShowMessage(finalMoveMessage, true); // Show the message with options
        }
    }

    // This method is called when the player exits the trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object is tagged as "Player"
        {
            Debug.Log("Player exited the trigger zone!");
            gameManager.HideMessage(); // Hide the message when the player leaves the zone
        }
    }
}
