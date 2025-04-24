using UnityEngine;
using UnityEngine.UI;

public class MoveTracker : MonoBehaviour
{
    public static bool moveMade = false;

    public GameObject winText;
    public GameObject wrongText;

    public Transform winningSquare;

    // This method takes the position of the placed piece
    public void RegisterMove(Vector3 piecePosition)
    {
        moveMade = true;

        float distanceToWin = Vector3.Distance(piecePosition, winningSquare.position);

        if (distanceToWin < 0.2f)
        {
            winText.SetActive(true);
        }
        else
        {
            wrongText.SetActive(true);
        }
    }
}
