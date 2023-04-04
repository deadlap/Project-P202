using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenerateNumberSlot : MonoBehaviour
{
    [SerializeField] GameObject slot;
    [SerializeField] GameObject content;
    [SerializeField] public List<string> numberInSlot;
    
    void Start()
    {
        CreateElement();
    }

    public void CreateElement() {
        foreach (string number in numberInSlot)
        {
            slot = Instantiate(slot, content.transform, true);
            TextMeshProUGUI topLayerText = slot.GetComponentInChildren<TextMeshProUGUI>();
            topLayerText.text = number;
        }
    }
}
