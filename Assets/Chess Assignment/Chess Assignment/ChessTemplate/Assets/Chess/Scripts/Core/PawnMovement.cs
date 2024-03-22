using UnityEngine;

public class PawnMovement : MonoBehaviour
{
    public GameObject moveIndicatorPrefab; // Prefab for the indicator dot
    private GameObject moveIndicator; // Reference to the instantiated move indicator
    public LayerMask obstacleLayer; // Layer mask for obstacles 
    public float tileDistance = 1f; // Distance between tiles

    void OnMouseDown()
    {
        // Check if the pawn can move forward one tile
        if (CanMoveForward())
        {
           
            ShowMoveIndicator();
        }
    }

    bool CanMoveForward()
    {
        // Calculate the position of the tile in front of the pawn
        Vector3 forwardPosition = transform.position + Vector3.up * tileDistance;

        // Perform a raycast to check for obstacles (other pieces) in front of the pawn
        RaycastHit2D hit = Physics2D.Raycast(forwardPosition, Vector2.zero, 0f, obstacleLayer);

        // If there's no obstacle in front of the pawn, return true (can move forward)
        return hit.collider == null;
    }



    void ShowMoveIndicator()
    {
        // Calculate the position where the move indicator should appear
        Vector3 targetPosition = transform.position + Vector3.up * tileDistance;

        // Check if the target position is within the chessboard boundaries
        if (IsWithinChessboardBounds(targetPosition))
        {
            // Instantiate the move indicator dot at the target position
            moveIndicator = Instantiate(moveIndicatorPrefab, targetPosition, Quaternion.identity);

            // Destroy the move indicator after 2 seconds
            Destroy(moveIndicator, 2f);
        }
    }

    bool IsWithinChessboardBounds(Vector3 position)
    {
        
        float minX = -4f; 
        float maxX = 4f; 
        float minY = -4f; 
        float maxY = 4f; 

        return position.x >= minX && position.x <= maxX && position.y >= minY && position.y <= maxY;
    }


}
