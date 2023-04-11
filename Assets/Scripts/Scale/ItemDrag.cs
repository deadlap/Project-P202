using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    CanvasGroup cg;
    [HideInInspector] public Transform newParent;
    [SerializeField] public Transform originalParent;
    public int count;

    void Awake() {
        cg = GetComponent<CanvasGroup>();
        var parent= transform.parent;
        originalParent = parent;
        newParent = parent;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        cg.alpha = .7f;
        cg.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position += (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData) {
        cg.alpha = 1f;
        cg.blocksRaycasts = true;
        transform.SetParent(newParent);
        if (count == 0) return;
        ReturnToOriginalParent();
    }

    void ReturnToOriginalParent() {
        newParent = originalParent;
        transform.SetParent(newParent);
        count = 0;
    }
}
