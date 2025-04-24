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
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        originalPosition = transform.position;
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Hook into grab/drop events
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnDestroy()
    {
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        Debug.Log("Dropped: " + name);

        // You could snap the piece to a grid here if needed
        // Or validate the move after drop
    }

    public bool IsMoveValid(Vector3 targetPosition)
    {
        float distance = Vector3.Distance(transform.position, targetPosition);
        return distance < 3.0f;
    }

    public void OnPieceSelected()
    {
        Debug.Log("Piece selected: " + name);
    }

    public void MoveTo(Vector3 newPosition)
    {
        if (IsMoveValid(newPosition))
        {
            transform.position = newPosition;
        }
        else
        {
            Debug.Log("Invalid move!");
        }
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
    }
}
