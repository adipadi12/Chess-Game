using System.Reflection;
using UnityEngine;
using System.Collections;

public class QueenMovement : MonoBehaviour
{
    public GameObject moveIndicatorPrefab; // Prefab for the indicator dot
    private GameObject[,] moveIndicators; // 2D array to store references to the instantiated move indicators
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
        

        // Check all possible directions for the queen's movement
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right,
                                 new Vector2(1, 1), new Vector2(-1, 1), new Vector2(1, -1), new Vector2(-1, -1) };

        // Instantiate move indicators for each direction
        moveIndicators = new GameObject[directions.Length, 8]; // 8 is the maximum number of tiles in a direction on an 8x8 chessboard

        for (int i = 0; i < directions.Length; i++)
        {
            GenerateMoveIndicatorsInDirection(directions[i], i);
        }

    }

    void GenerateMoveIndicatorsInDirection(Vector2 direction, int index)
    {
        Vector3 currentPosition = transform.position;

        for (int i = 1; i < 8; i++) // Maximum distance on an 8x8 chessboard
        {
            Vector3 targetPosition = currentPosition + (Vector3)direction * i * tileDistance;

            // Check if the target position is within the chessboard boundaries


            // Instantiate the move indicator dot at the target position if there's no obstacle in the way

            if (!IsWithinChessboardBounds(targetPosition))
                break;

            // Instantiate the move indicator dot at the target position if there's no obstacle in the way
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(targetPosition, Vector2.zero, 0f);
                if (hit.collider == null)
                {
                    // Instantiate the move indicator dot at the target position
                    moveIndicators[index, i - 1] = Instantiate(moveIndicatorPrefab, targetPosition, Quaternion.identity);

                }
                else
                {
                    break;
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
        for (int i = 0; i < moveIndicators.GetLength(0); i++)
        {
            for (int j = 0; j < moveIndicators.GetLength(1); j++)
            {
                if (moveIndicators[i, j] != null)
                {
                    Destroy(moveIndicators[i, j]);
                }
            }
        }
    }

}
