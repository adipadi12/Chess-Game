using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class ChessPieceController : MonoBehaviour {
        [SerializeField] private ChessPieceType pieceType; // Enum defining the type of chess piece

        private void OnMouseDown() {
            ChessBoardPlacementHandler.Instance.ClearHighlights(); // Clear previous highlights
            
            int currentRow = GetComponent<ChessPlayerPlacementHandler>().row;
            int currentColumn = GetComponent<ChessPlayerPlacementHandler>().column;

            // Calculate possible moves based on the type of chess piece
            List<Vector2Int> possibleMoves = CalculatePossibleMoves(pieceType, currentRow, currentColumn);

            // Highlight possible moves
            foreach (Vector2Int move in possibleMoves) {
                ChessBoardPlacementHandler.Instance.Highlight(move.x, move.y);
            }
            
            // Highlight enemy pieces that can be captured
            HighlightCapturableEnemies(pieceType, currentRow, currentColumn);
        }

        private List<Vector2Int> CalculatePossibleMoves(ChessPieceType type, int currentRow, int currentColumn) {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();

            // Implement logic to calculate possible moves based on the type of chess piece
            // Example:
            // For pawn: Check if the tile in front is empty, diagonal tiles for capture, etc.
            // For rook: Check vertical and horizontal tiles until an obstruction is found
            
            // Dummy implementation for demonstration
            for (int i = currentRow - 1; i <= currentRow + 1; i++) {
                for (int j = currentColumn - 1; j <= currentColumn + 1; j++) {
                    if (i >= 0 && i < 8 && j >= 0 && j < 8) {
                        possibleMoves.Add(new Vector2Int(i, j));
                    }
                }
            }

            return possibleMoves;
        }

        private void HighlightCapturableEnemies(ChessPieceType type, int currentRow, int currentColumn) {
            // Implement logic to highlight enemy pieces that can be captured
            // Example:
            // For each enemy piece within attacking range, check if it can be captured and highlight the tile
            
            // Dummy implementation for demonstration
            ChessPieceType enemyType = type == ChessPieceType.White ? ChessPieceType.Black : ChessPieceType.White;
            List<Vector2Int> enemyPositions = GetEnemyPiecePositions(enemyType);
            foreach (Vector2Int enemyPosition in enemyPositions) {
                ChessBoardPlacementHandler.Instance.Highlight(enemyPosition.x, enemyPosition.y);
            }
        }

        private List<Vector2Int> GetEnemyPiecePositions(ChessPieceType enemyType) {
            List<Vector2Int> enemyPositions = new List<Vector2Int>();

            // Implement logic to get positions of enemy pieces of specified type
            // Dummy implementation for demonstration
            // Assume enemy pieces are placed randomly for testing
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (Random.Range(0, 2) == 0) {
                        enemyPositions.Add(new Vector2Int(i, j));
                    }
                }
            }

            return enemyPositions;
        }
    }

    public enum ChessPieceType {
        White,
        Black
        // Add more types as needed (e.g., Pawn, Rook, Knight, Bishop, Queen, King)
    }
}
