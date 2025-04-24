using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public enum PieceType
{
    Pawn,
    Rook,
    Knight,
    Bishop,
    Queen,
    King
}

[RequireComponent(typeof(XRGrabInteractable))]
public class ChessPiece : MonoBehaviour
{
    public PieceType pieceType;
    public bool isWhite;

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void OnPieceSelected()
    {
        Debug.Log("Piece selected: " + name);
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!MoveTracker.moveMade && other.CompareTag("Board"))
        {
            MoveTracker moveTracker = FindObjectOfType<MoveTracker>();
            if (moveTracker != null)
            {
                moveTracker.RegisterMove();

                // Optional: Snap to nearest square (add snapping logic here if you want)
                // transform.position = SnapToGrid(transform.position);

                // Disable further interaction
                GetComponent<XRGrabInteractable>().enabled = false;

                Debug.Log("Piece placed on board. Move registered.");
            }
        }
    }
}
