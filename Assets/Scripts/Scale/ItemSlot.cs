using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    GameObject hasDropped;
    ItemDrag itemDrag;
    [SerializeField] TextMeshProUGUI text;

    public void OnDrop(PointerEventData eventData)
    {
        hasDropped = eventData.pointerDrag;
        itemDrag = hasDropped.GetComponent<ItemDrag>();
        CorrectItem();
    }

    void CorrectItem()
    {
        if (!itemDrag.gameObject.CompareTag(gameObject.tag)) return;
        Queue<ItemDrag> slottedItem = new Queue<ItemDrag>();
        string textOnItem = itemDrag.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        text.text = textOnItem;
        slottedItem.Enqueue(itemDrag);
        foreach (var item in slottedItem)
        {
            
            Debug.Log(item);
        }
        
        if (slottedItem.Count <= 1) return;
        itemDrag.gameObject.SetActive(true);
        Debug.Log("kom tilbage john");
    }
}
