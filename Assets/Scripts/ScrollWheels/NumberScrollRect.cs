using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ScrollWheels {
    public class NumberScrollRect : MonoBehaviour {
        [SerializeField] GameObject content;
        [SerializeField] float elementSize;
        [SerializeField] float elementSpacing;

        [SerializeField] List<string> elements;

        void Start() {
            CreatElement();
        }
    
        void Update() {
            AssignStringToElement();
        }

        void CreatElement() {
            foreach (string element in elements) {
                GameObject newElement = new("Element");
                newElement.tag = "Element";
                newElement.transform.SetParent(content.transform);
                newElement.transform.localScale = new Vector3(elementSize, elementSize, 0);

                Rigidbody2D rb = newElement.AddComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Static;

                BoxCollider2D col = newElement.AddComponent<BoxCollider2D>();
                col.isTrigger = true;

                TextMeshProUGUI text = newElement.AddComponent<TextMeshProUGUI>();
                text.color = Color.grey;
                text.autoSizeTextContainer = true;
            }
            content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, elements.Count * elementSpacing);
        }

        void AssignStringToElement() {
            for (int i = 0; i < elements.Count; i++) {
                content.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = elements[i];
            }
        }
    }
}
