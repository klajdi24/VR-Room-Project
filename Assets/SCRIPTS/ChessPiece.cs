using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public enum PieceType
{
    Pawn, Rook, Knight, Bishop, Queen, King
}

[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(Rigidbody))]
public class ChessPiece : MonoBehaviour
{
    public PieceType pieceType;
    public bool isWhite;
    public Transform snapAnchor; // Drag the SnapAnchor here in Inspector

    private XRGrabInteractable grab;
    private Rigidbody rb;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private bool hasWon = false;
    private bool hasSnapped = false;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        grab = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        grab.selectExited.AddListener(OnReleased);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasSnapped || hasWon) return;

        if (other.CompareTag("WinningSquare") && pieceType == PieceType.Queen && isWhite)
        {
            Debug.Log("✅ Queen entered winning square!");

            // Destroy the black pawn
            GameObject blackPawn = GameObject.FindGameObjectWithTag("BlackPawn");
            if (blackPawn != null)
            {
                Destroy(blackPawn);
            }

            // Freeze physics before teleporting
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            // Snap into place
            MoveTracker tracker = Object.FindObjectOfType<MoveTracker>();
            if (tracker != null)
            {
                if (snapAnchor != null)
                {
                    // Use local offset directly now that it's a child
                    transform.position = tracker.winningSquare.position - snapAnchor.localPosition;
                }
                else
                {
                    transform.position = tracker.winningSquare.position;
                }

                transform.rotation = Quaternion.Euler(0, 0, 0);

                grab.enabled = false;
                hasSnapped = true;
                hasWon = true;

                tracker.ShowWin();
                Debug.Log("✅ Win condition met — snapping into place!");
            }
        }
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        if (hasWon || hasSnapped) return;

        Debug.Log("❌ Invalid move — snapping back.");
        StartCoroutine(ResetAfterPhysics());

        MoveTracker tracker = Object.FindObjectOfType<MoveTracker>();
        if (tracker != null)
        {
            tracker.ShowWrong();
        }
    }

    private IEnumerator ResetAfterPhysics()
    {
        yield return new WaitForFixedUpdate();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
