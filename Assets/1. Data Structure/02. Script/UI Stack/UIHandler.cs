using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform parentRect;
    
    private Vector2 basePose;
    private Vector2 startPos;

    private Vector2 moveOffset;

    private void Awake()
    {
        parentRect = transform.parent.GetComponent<RectTransform>();

        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        basePose = parentRect.anchoredPosition;
        startPos = eventData.position;

        parentRect.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        moveOffset = eventData.position - startPos;
        parentRect.anchoredPosition = basePose + moveOffset;
    }
}
