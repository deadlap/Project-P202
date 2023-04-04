using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenerateNumberSlot : MonoBehaviour
{
    [SerializeField] GameObject slot;
    [SerializeField] GameObject content;
    [SerializeField] List<string> numberInSlot;
    
    void Start()
    {
        CreatElement();
    }

    void CreatElement() {
        foreach (string number in numberInSlot)
        {
            slot = Instantiate(slot, content.transform, true);
            TextMeshProUGUI topLayerText = slot.GetComponentInChildren<TextMeshProUGUI>();
            topLayerText.text = number;
        }
    }
}
