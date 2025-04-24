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
[RequireComponent(typeof(Rigidbody))]
public class ChessPiece : MonoBehaviour
{
    public PieceType pieceType;
    public bool isWhite;

    private Vector3 originalPosition;
    private bool hasBeenPlaced = false;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenPlaced) return;

        if (other.CompareTag("WinningSquare") || other.CompareTag("Board"))
        {
            MoveTracker moveTracker = FindObjectOfType<MoveTracker>();
            if (moveTracker != null && !MoveTracker.moveMade)
            {
                // Snap to exact center of square
                transform.position = other.transform.position;
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0); // keep upright

                // Freeze movement
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.constraints = RigidbodyConstraints.FreezeAll;

                // Disable grabbing
                GetComponent<XRGrabInteractable>().enabled = false;

                // Register the move with position
                moveTracker.RegisterMove(transform.position);

                hasBeenPlaced = true;
                Debug.Log("Piece placed and move registered.");
            }
        }
    }
}
