using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Button useButton;
    public Button dropButton;
    public Button cancelButton;

    public RectTransform container;
    public RectTransform rectTransform;

    public void TooltipPosition(Vector2 slotPosition)
    {
        var position = slotPosition.x > 500 ? new Vector2(slotPosition.x - 220, slotPosition.y) : new Vector2(slotPosition.x + 220, slotPosition.y);

        var containerPosition = container.position;
        var pivotX = position.x / containerPosition.x;
        var pivotY = position.y / containerPosition.y;

        rectTransform.pivot = new Vector2(0.5f, pivotY);
        transform.position = position;
    }

    public void RemoveAllListeners()
    {
        useButton.onClick.RemoveAllListeners();
        dropButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();
    }
}