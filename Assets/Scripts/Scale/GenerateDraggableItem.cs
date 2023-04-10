using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenerateDraggableItem : MonoBehaviour
{
    [SerializeField] GameObject draggableItem;
    [SerializeField] GameObject content;
    [SerializeField] public List<string> numberInItem;
    
    void Start() {
        CreateElement();
    }

    public void CreateElement() {
        foreach (string number in numberInItem)
        {
            draggableItem = Instantiate(draggableItem, content.transform, true);
            TextMeshProUGUI topLayerText = draggableItem.GetComponentInChildren<TextMeshProUGUI>();
            topLayerText.text = number;
            draggableItem.transform.GetChild(0).tag = number;
        }
    }
}
