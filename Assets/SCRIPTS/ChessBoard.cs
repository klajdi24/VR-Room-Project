using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    private ChessPiece selectedPiece;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.TryGetComponent(out ChessPiece piece))
                {
                    SelectPiece(piece);
                }
                else if (selectedPiece != null)
                {
                    MoveSelectedPiece(hit.point);
                }
            }
        }
    }

    void SelectPiece(ChessPiece piece)
    {
        selectedPiece = piece;
        selectedPiece.OnPieceSelected();
    }

    void MoveSelectedPiece(Vector3 position)
    {
        selectedPiece.MoveTo(position);
        selectedPiece = null;
    }
}
