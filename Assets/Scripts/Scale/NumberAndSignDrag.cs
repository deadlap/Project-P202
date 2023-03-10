using UnityEngine;
using UnityEngine.EventSystems;

public class NumberAndSignDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    RectTransform rect;
    CanvasGroup cg;
    Vector2 defPos;
    bool inserted;
        
    void Awake()
    {
        rect = GetComponent<RectTransform>();
        cg = GetComponent<CanvasGroup>();
        defPos = rect.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var tf = transform;
        cg.alpha = .7f;
        cg.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cg.alpha = 1f;
        cg.blocksRaycasts = true;
        rect.anchoredPosition = defPos;
    }
}
