using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ValueSlot : MonoBehaviour, IDropHandler
{
    GameObject hasDropped;
    NumberAndSignDrag numberAndSignDrag;
    [SerializeField] TextMeshPro text;

    public void OnDrop(PointerEventData eventData)
    {
        hasDropped = eventData.pointerDrag;
        numberAndSignDrag = hasDropped.GetComponent<NumberAndSignDrag>();
        CorrectItem();
    }

    void CorrectItem()
    {
        if (!numberAndSignDrag.gameObject.CompareTag(gameObject.tag)) return;
        text = numberAndSignDrag.GetComponentInChildren<TextMeshPro>();
        Debug.Log("yes it dropped");
    }
}
