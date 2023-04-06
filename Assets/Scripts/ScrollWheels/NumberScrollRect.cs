using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScrollWheels {
    public class NumberScrollRect : MonoBehaviour
    {
        [SerializeField] ScrollRect scrollRect;
        [SerializeField] RectTransform content;
        [SerializeField] float elementSize;
        [SerializeField] float elementSpacing;
        [SerializeField] List<string> elements;
        GameObject newElement;
        bool isActive;

        void Start() {
            Invoke(nameof(CreateElement), .08f); //
            Invoke(nameof(BeginAtTop), .09f); //Bliver invoket med delay, ellers driller det.
        }
    
        void Update() {
            AssignStringToElement();
        }

        void CreateElement() {
            foreach (string element in elements) {
                newElement = new("Element");
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
            isActive = true; //Så AssignStringToElement() kun kører når BeginAtTop() har kørt.
        }

        void AssignStringToElement() {
            if (!isActive) return;
            for (int i = 0; i < elements.Count; i++) {
                content.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = elements[i];
            }
            isActive = true;
        }

        void BeginAtTop() {
            var elementIndex = newElement.transform.GetSiblingIndex();
            var pos = scrollRect.content.transform.childCount / elementIndex;
            scrollRect.verticalNormalizedPosition = pos;
        }
    }
}
