using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    CanvasGroup cg;
    public Transform newParent;

    void OnEnable()
    {
        ScaleEvent.ItemSlotFull += OnItemSlotFull;
    }

    void OnItemSlotFull()
    {
        Debug.Log("cant put in");
    }

    void OnDisable()
    {
        ScaleEvent.ItemSlotFull -= OnItemSlotFull;
    }
    void Awake()
    {
        cg = GetComponent<CanvasGroup>();
        newParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        cg.alpha = .7f;
        cg.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position += (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cg.alpha = 1f;
        cg.blocksRaycasts = true;
        transform.SetParent(newParent);
    }
}
