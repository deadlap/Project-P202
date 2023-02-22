using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberScrollRect : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] float elementSize;
    [SerializeField] float elementSpacing;

    [SerializeField] List<string> elements;

        void Start()
        {
            CreatElement();
        }
    
        void Update()
        {
            AssignStringToElement();
        }

        void CreatElement() 
        {
            foreach (string element in elements)
            {
                GameObject newElement = new("Element");
                newElement.transform.SetParent(content.transform);
                newElement.transform.localScale = new Vector3(elementSize, elementSize, 0);

                TextMeshProUGUI text = newElement.AddComponent<TextMeshProUGUI>();
                text.color = Color.black;
                text.autoSizeTextContainer = true;
            }
            content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, elements.Count * elementSpacing);
        }

        void AssignStringToElement() 
        {
            for (int i = 0; i < elements.Count; i++)
            {
                content.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = elements[i];
            }
        }
}
