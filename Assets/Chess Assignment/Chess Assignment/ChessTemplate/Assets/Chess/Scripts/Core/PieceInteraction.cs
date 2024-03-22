using UnityEngine;

public class PieceInteraction : MonoBehaviour
{
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void OnMouseEnter()
    {
        // Increase the scale of the piece
        transform.localScale = originalScale * 1.2f; // You can adjust the scale factor as needed
    }

    void OnMouseExit()
    {
        // Revert the scale back to its original size
        transform.localScale = originalScale;
    }
}
