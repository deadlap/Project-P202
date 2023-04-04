using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    ItemDrag draggedItem;
    TextMeshProUGUI textItem;
    GameObject currentItem;
    GameObject prevItem;

    public void OnDrop(PointerEventData eventData) {
        draggedItem = eventData.pointerDrag.GetComponent<ItemDrag>(); 
        Invoke(nameof(CorrectItemType), .01f);
    }

    void CorrectItemType() {
        if (!draggedItem.CompareTag(gameObject.tag)) return;
        

        switch (gameObject.transform.childCount)
        {
            case 0:
                draggedItem.newParent = transform;
                currentItem = draggedItem.gameObject;
                currentItem.transform.SetParent(draggedItem.newParent);
                draggedItem.pleaseHelpMeThisIsNotAGoodSolution = 1;
                Debug.Log("kom bar do");
                break;
            case 1:
                currentItem.transform.SetParent(draggedItem.originalParent);
                draggedItem.newParent = transform;
                draggedItem.transform.SetParent(draggedItem.newParent);
                draggedItem.pleaseHelpMeThisIsNotAGoodSolution = 1;
                Debug.Log("byt");
                break;
        }
    }
}
                //potentiel fix: destroy current item og spawn en ny ¯\_(ツ)_/¯
//TODO lav prefabs af gameobjects med itemslot.cs på og smid dem i et grid
