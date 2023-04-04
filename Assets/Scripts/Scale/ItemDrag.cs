using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    ItemSlot itemSlot;
    CanvasGroup cg;
    [HideInInspector] public Transform newParent;
    [SerializeField] public Transform originalParent;
    public int pleaseHelpMeThisIsNotAGoodSolution;

    void OnEnable() {
        ScaleEvent.ItemSlotFull += OnItemSlotFull;
    }

    void OnItemSlotFull() {
        Debug.Log("cant put in");
    }

    void OnDisable() {
        ScaleEvent.ItemSlotFull -= OnItemSlotFull;
    }
    void Awake() {
        cg = GetComponent<CanvasGroup>();
        var parent= transform.parent;
        originalParent = parent;
        newParent = parent;
        ReturnToOriginalParent();
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
        if (pleaseHelpMeThisIsNotAGoodSolution == 0) return;
        ReturnToOriginalParent();
    }

    public void ReturnToOriginalParent()
    {
        newParent = originalParent;
        transform.SetParent(newParent);
        pleaseHelpMeThisIsNotAGoodSolution = 0;
    }
}
