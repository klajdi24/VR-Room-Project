using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public PieceType pieceType;  // Store the piece type (e.g., Pawn, Queen)
    public bool isWhitePiece;    // Is this piece white or black?

    private ChessBoard chessBoard;

    private void Start()
    {
        chessBoard = FindObjectOfType<ChessBoard>(); // Get the reference to the Chessboard
    }

    // Called when the piece is selected (to show valid moves)
    public void OnPieceSelected()
    {
        Debug.Log(pieceType + " selected!");
        chessBoard.ShowAvailableMoves(this); // Show valid moves based on piece type
    }

    // Validates if a given move is valid based on the piece type
    public bool IsMoveValid(Vector3 destination)
    {
        switch (pieceType)
        {
            case PieceType.Pawn:
                return ValidatePawnMove(destination);
            case PieceType.Rook:
                return ValidateRookMove(destination);
            case PieceType.Knight:
                return ValidateKnightMove(destination);
            case PieceType.Bishop:
                return ValidateBishopMove(destination);
            case PieceType.Queen:
                return ValidateQueenMove(destination);
            case PieceType.King:
                return ValidateKingMove(destination);
            default:
                return false;
        }
    }

    // Example: Pawn can only move one square forward (basic logic)
    private bool ValidatePawnMove(Vector3 destination)
    {
        // Logic for validating pawn movement (simplified)
        return true;
    }

    // Other piece movement validation methods (Rook, Knight, etc.)
}
