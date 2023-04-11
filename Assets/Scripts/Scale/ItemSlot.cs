using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler {
    ItemDrag draggedItem;
    GameObject currentItem;
    TextMeshProUGUI itemValue;
    [SerializeField] TextMeshProUGUI currentValue;
    public GameObject correctParent;
    bool noChildren;


    public void OnDrop(PointerEventData eventData) {
        draggedItem = eventData.pointerDrag.GetComponent<ItemDrag>();
        Invoke(nameof(CorrectItemType), .0000000000000001f); //Needs delay to get component. 
    }

    void Update() {
        if (transform.childCount == 0 && !noChildren) {
            currentValue.text = "";
            noChildren = true;
        }
    }

    void CorrectItemType() {
        if (!draggedItem.CompareTag(tag)) return;
        switch (transform.childCount) {
            case 0:
                InsertItem();
                break;
            case 1:
                currentItem.transform.SetParent(correctParent.transform);
                InsertItem();
                break;
        }
    }

    public void InsertItem() {
        noChildren = false;
        currentItem = draggedItem.gameObject;
        draggedItem.newParent = transform;
        draggedItem.transform.SetParent(draggedItem.newParent);
        itemValue = draggedItem.GetComponentInChildren<TextMeshProUGUI>();
        currentValue.text = itemValue.text;
        correctParent = GameObject.FindGameObjectWithTag(itemValue.text);
        draggedItem.count = 1;
    }
}
