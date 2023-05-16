using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler {
    ItemDrag draggedItem;
    GameObject currentItem;
    TextMeshProUGUI itemValue;
    [SerializeField] TextMeshProUGUI currentValue;
    [HideInInspector] public GameObject correctParent;
    AudioSource audioSource;
    bool noChildren;

    void Awake()
    {
        audioSource = GameObject.Find("Scale").GetComponent<AudioSource>();
    }
    
    void Update() {
        if (transform.childCount == 0 && !noChildren) {
            currentValue.text = "";
            currentValue.alpha = 0;
            noChildren = true;
        }
    }

    public void OnDrop(PointerEventData eventData) {
        draggedItem = eventData.pointerDrag.GetComponent<ItemDrag>();
        Invoke(nameof(CorrectItemType), .0000000000000001f); //Needs delay to get component. 
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

    void InsertItem() {
        noChildren = false;
        audioSource.PlayOneShot(audioSource.clip);
        currentItem = draggedItem.gameObject;
        draggedItem.newParent = transform;
        draggedItem.transform.SetParent(draggedItem.newParent);
        itemValue = draggedItem.GetComponentInChildren<TextMeshProUGUI>();
        currentValue.text = itemValue.text;
        correctParent = GameObject.FindGameObjectWithTag(itemValue.text);
        draggedItem.count++;
    }
}
