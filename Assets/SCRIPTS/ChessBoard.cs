using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;  // For XR controller input

public class ChessBoard : MonoBehaviour
{
    public GameObject selectedPiece;   // The currently selected piece
    public List<Vector3> availableMoves = new List<Vector3>(); // List of valid move positions
    public GameObject moveMarkerPrefab;  // Prefab to mark valid move spots
    public XRController leftController;  // Reference to the left VR controller
    public XRController rightController;  // Reference to the right VR controller
    private RaycastHit hitInfo;

    private void Update()
    {
        // Use the left or right controller to cast a ray and detect objects (this will be customized based on your setup)
        CastRayFromController(leftController);
        CastRayFromController(rightController);
    }

    // Cast a ray from the provided controller
    private void CastRayFromController(XRController controller)
    {
        if (controller == null)
            return;

        Ray ray = new Ray(controller.transform.position, controller.transform.forward);
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.CompareTag("ChessPiece"))
            {
                ChessPiece piece = hitInfo.collider.GetComponent<ChessPiece>();
                piece.OnPieceSelected(); // Show valid moves for selected piece
            }
            else if (hitInfo.collider.CompareTag("AvailableMove"))
            {
                // If the user clicks on a valid move position
                MovePiece(hitInfo.collider.transform.position);
            }
        }
    }

    // Display the available moves for the selected piece
    public void ShowAvailableMoves(ChessPiece piece)
    {
        availableMoves.Clear();  // Clear previous valid moves

        Vector3 piecePosition = piece.transform.position;

        // Now show available moves based on the piece type
        for (float x = -1f; x <= 1f; x++)
        {
            for (float z = -1f; z <= 1f; z++)
            {
                Vector3 targetPos = new Vector3(piecePosition.x + x, piecePosition.y, piecePosition.z + z);

                // Check if the move is valid for the selected piece
                if (piece.IsMoveValid(targetPos))
                {
                    availableMoves.Add(targetPos);
                    // Create a visual marker for the valid move spot (optional)
                    Instantiate(moveMarkerPrefab, targetPos, Quaternion.identity);
                }
            }
        }
    }

    // Move the piece to a new position if the move is valid
    public void MovePiece(Vector3 newPosition)
    {
        if (selectedPiece != null)
        {
            selectedPiece.transform.position = newPosition; // Move the piece to the new position
            selectedPiece = null; // Reset the selected piece after moving
        }
    }
}
