using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    ItemDrag[] slottedItems;
    ItemDrag itemDrag;
    TextMeshProUGUI textItem;
    GameObject currentItem;

    void Awake() {
        textItem = GetComponentInChildren<TextMeshProUGUI>();
        textItem.text = "";
    }

    public void OnDrop(PointerEventData eventData) {
        itemDrag = eventData.pointerDrag.GetComponent<ItemDrag>(); 
        Invoke(nameof(CorrectItem), .01f);
    }

    void CorrectItem() {
        var itemGO = itemDrag.gameObject;
        if (!itemGO.CompareTag(gameObject.tag)) return;
        string textOnItem = itemGO.GetComponentInChildren<TextMeshProUGUI>().text;

        if (textItem.text == "") {
            textItem.text = textOnItem;
            currentItem = itemGO;
            currentItem.gameObject.SetActive(false);
        }
        else if (textItem.text != textOnItem) {
            string newTextOnItem = itemGO.GetComponentInChildren<TextMeshProUGUI>().text;
            textItem.text = newTextOnItem;
            currentItem.gameObject.SetActive(true);
            currentItem = itemGO;
            itemGO.gameObject.SetActive(false);
        }
    }
}
