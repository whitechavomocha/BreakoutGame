using UnityEngine;
using UnityEngine.EventSystems;

public class InputPanel : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static InputPanel instance;

    [System.NonSerialized] public float horizontal;

    private Vector2 lastPosition = Vector2.zero;

    private void Awake()
    {
        instance = this;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - lastPosition;
        horizontal = direction.x / Screen.width;
        lastPosition = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        horizontal = 0;
        lastPosition = Vector2.zero;
    }
}