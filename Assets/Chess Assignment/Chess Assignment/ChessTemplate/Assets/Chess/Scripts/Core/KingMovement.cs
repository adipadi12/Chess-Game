using UnityEngine;
using System.Collections;

public class KingMovement : MonoBehaviour
{
    public GameObject moveIndicatorPrefab; // Prefab for the indicator dot
    private GameObject[] moveIndicators; // Array to store references to the instantiated move indicators
    public LayerMask obstacleLayer; // Layer mask for obstacles 
    public float tileDistance = 1f; // Distance between tiles

    void OnMouseDown()
    {
        // Generate move indicators for all possible moves
        GenerateMoveIndicators();
        StartCoroutine(DestroyMoveIndicatorsAfterDelay());

    }

    void GenerateMoveIndicators()
    {
        // Define all possible offsets for king's movement (including diagonals and adjacent squares)
        Vector2[] offsets = {
            new Vector2(1, 0), new Vector2(1, 1),
            new Vector2(0, 1), new Vector2(-1, 1),
            new Vector2(-1, 0), new Vector2(-1, -1),
            new Vector2(0, -1), new Vector2(1, -1)
        };

        // Instantiate move indicators for each offset
        moveIndicators = new GameObject[offsets.Length];

        for (int i = 0; i < offsets.Length; i++)
        {
            Vector3 targetPosition = transform.position + (Vector3)offsets[i] * tileDistance;

            // Check if the target position is within the chessboard bounds and there's no obstacle in the path
            if (IsWithinChessboardBounds(targetPosition))
            {
                // Check if there's already an object present at the target position using a raycast
                RaycastHit2D hit = Physics2D.Raycast(targetPosition, Vector2.zero, 0f);
                if (hit.collider == null)
                {
                    // Instantiate the move indicator dot at the target position
                    moveIndicators[i] = Instantiate(moveIndicatorPrefab, targetPosition, Quaternion.identity);
                }
            }
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

    IEnumerator DestroyMoveIndicatorsAfterDelay()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Destroy all instantiated move indicators
        for (int i = 0; i < moveIndicators.Length; i++)
        {
            if (moveIndicators[i] != null)
            {
                Destroy(moveIndicators[i]);
            }
        }
    }
}
