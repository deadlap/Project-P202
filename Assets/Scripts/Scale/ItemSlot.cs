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

    void Awake()
    {
        textItem = GetComponentInChildren<TextMeshProUGUI>();
        textItem.text = "";
    }

    public void OnDrop(PointerEventData eventData) {
        itemDrag = eventData.pointerDrag.GetComponent<ItemDrag>(); 
        CorrectItem();
    }

    void CorrectItem() {
        if (!itemDrag.gameObject.CompareTag(gameObject.tag)) return;
        string textOnItem = itemDrag.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;

        if (textItem.text == "") {
            textItem.text = textOnItem;
            Debug.Log(textOnItem);
        }
        else {
            Debug.Log("optaget");
        }
        //itemDrag.gameObject.SetActive(true);
        //Debug.Log("kom tilbage john");
    }
    
}
