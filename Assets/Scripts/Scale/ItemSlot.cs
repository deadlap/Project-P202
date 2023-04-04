using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    List<GameObject> slottedItems;
    ItemDrag draggedItem;
    TextMeshProUGUI textItem;
    GameObject currentItem;

    void Awake()
    {
        textItem = GetComponentInChildren<TextMeshProUGUI>();
        textItem.text = "";
    }

    public void OnDrop(PointerEventData eventData) {
        draggedItem = eventData.pointerDrag.GetComponent<ItemDrag>(); 
        Invoke(nameof(CorrectItemType), .01f);
        draggedItem.newParent = transform;
    }

    void CorrectItemType() {
        var itemGO = draggedItem.gameObject;
        itemGO = new GameObject();
        itemGO.transform.SetParent(draggedItem.newParent);
        if (!itemGO.CompareTag(gameObject.tag)) return;
        //string textOnItem = itemGO.GetComponentInChildren<TextMeshProUGUI>().text;

        if (slottedItems.Count >= 0)
        {
            Debug.Log("der er ikke plads");
        }
        else
        {
            Debug.Log("kom bar do");
        }
        
        
        
        
        
        // if (textItem.text == "") {
        //     textItem.text = textOnItem;
        //     currentItem = itemGO;
        //     currentItem.gameObject.SetActive(false);
        // }
        // else if (textItem.text != textOnItem) {
        //     string newTextOnItem = itemGO.GetComponentInChildren<TextMeshProUGUI>().text;
        //     textItem.text = newTextOnItem;
        //     currentItem.gameObject.SetActive(true);
        //     currentItem = itemGO;
        //     itemGO.gameObject.SetActive(false);
        // }
    }
}
