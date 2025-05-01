 using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public enum PieceType { Pawn, Rook, Knight, Bishop, Queen, King }

[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(Rigidbody))]
public class ChessPiece : MonoBehaviour
{
    public PieceType pieceType;
    public bool isWhite;
    public Transform snapAnchor; 

    private XRGrabInteractable grab;
    private Rigidbody rb;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private bool hasWon = false;

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
        if (hasWon) return;

        if (other.CompareTag("WinningSquare") && pieceType == PieceType.Queen && isWhite)
        {
            Debug.Log("👑 Queen entered winning square!");

            
            GameObject blackPawn = GameObject.FindGameObjectWithTag("BlackPawn");
            if (blackPawn != null)
            {
                Destroy(blackPawn);
            }

            
            if (grab.isSelected)
            {
                grab.interactionManager.SelectExit(grab.interactorsSelecting[0], grab);
            }

            // Snap Queen perfectly to WinningAnchor
            MoveTracker tracker = FindObjectOfType<MoveTracker>();
            if (tracker != null && tracker.winningAnchor != null)
            {
                transform.position = tracker.winningAnchor.position;
                transform.rotation = tracker.winningAnchor.rotation;

                tracker.ShowWin();
            }
            else
            {
                Debug.LogError(" MoveTracker or WinningAnchor missing!");
            }

            
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            
            grab.enabled = false;

            
            ChessSnapper snapper = GetComponent<ChessSnapper>();
            if (snapper != null)
            {
                Destroy(snapper);
            }

            hasWon = true;
            Debug.Log("Win condition met — snapped queen perfectly!");
        }
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        if (hasWon)
        {
            Debug.Log(" Released after win — no reset needed.");
            return;
        }

          MoveTracker tracker = FindObjectOfType<MoveTracker>();
    if (tracker != null)
    {
        tracker.ShowWrong();
    }

    StartCoroutine(ResetAfterPhysics());
}

    private IEnumerator ResetAfterPhysics()
    {
        yield return new WaitForFixedUpdate();

        if (hasWon)
        {
            Debug.Log(" Already won — skip reset.");
            yield break;
        }

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
