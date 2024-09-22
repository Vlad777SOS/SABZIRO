using UnityEngine;
using UnityEngine.EventSystems;

public class MapDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform mapRectTransform;
    private Vector3 dragStartPosition;
    private RectTransform canvasRectTransform;  // Parent canvas for bounds checking

    void Start()
    {
        // Get the RectTransform components of the map and its parent canvas
        mapRectTransform = GetComponent<RectTransform>();
        canvasRectTransform = mapRectTransform.parent.GetComponent<RectTransform>();
    }

    // Called when the drag starts
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Store the starting position when dragging begins
        dragStartPosition = mapRectTransform.anchoredPosition;
    }

    // Called during the drag, adjusting the map's position
    public void OnDrag(PointerEventData eventData)
    {
        // Move the map according to the drag delta
        mapRectTransform.anchoredPosition += eventData.delta;

        // Ensure the map stays within the canvas bounds
        ClampMapPosition();
    }

    // Called when the drag ends (optional cleanup or future functionality can go here)
    public void OnEndDrag(PointerEventData eventData)
    {
        // You could add additional logic here if needed after the drag ends
    }

    // Clamp the map's position so it doesn't go out of the visible canvas bounds
    private void ClampMapPosition()
    {
        // Get the dimensions of the map and the canvas
        Vector3 clampedPosition = mapRectTransform.anchoredPosition;

        // Get the bounds of the canvas and map
        float canvasWidth = canvasRectTransform.rect.width;
        float canvasHeight = canvasRectTransform.rect.height;

        float mapWidth = mapRectTransform.rect.width;
        float mapHeight = mapRectTransform.rect.height;

        // Calculate the min and max bounds the map can move to (to avoid going out of the canvas)
        float minX = canvasWidth / 2 - mapWidth / 2;
        float maxX = mapWidth / 2 - canvasWidth / 2;
        float minY = canvasHeight / 2 - mapHeight / 2;
        float maxY = mapHeight / 2 - canvasHeight / 2;

        // Clamp the map's position within the bounds
        clampedPosition.x = Mathf.Clamp(mapRectTransform.anchoredPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(mapRectTransform.anchoredPosition.y, minY, maxY);

        // Apply the clamped position back to the map
        mapRectTransform.anchoredPosition = clampedPosition;
    }
}
