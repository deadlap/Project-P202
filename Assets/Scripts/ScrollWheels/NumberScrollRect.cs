using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ScrollWheels {
    public class NumberScrollRect : MonoBehaviour, IBeginDragHandler, IEndDragHandler {
        [SerializeField] RectTransform content;
        [SerializeField] RectTransform center;
        [SerializeField] int elementSize;
        [SerializeField] float snapMultiplier;
        [SerializeField] string[] elementValue;
        [SerializeField] List<GameObject> elements;
        GameObject newElement;
        int closestElement;
        int elementSpacing;
        float[] rawDistance;
        float[] absDistance;
        bool scrolling;
    
        void Start() {
            CreateElement();
        }

        void Update() {
            FindClosestElement();
        }

        void CreateElement() {
            foreach (var element in elementValue) {
                newElement = new("Element");
                newElement.tag = "Element";
                newElement.transform.SetParent(content.transform);
                newElement.transform.localScale = new Vector3(elementSize, elementSize, 0);
                
                BoxCollider2D col = newElement.AddComponent<BoxCollider2D>();
                col.isTrigger = true;

                TextMeshProUGUI text = newElement.AddComponent<TextMeshProUGUI>();
                text.fontSize = 28;
                text.color = Color.black;
                text.alpha = 0.3f;
                text.autoSizeTextContainer = true;
                text.alignment = TextAlignmentOptions.Center;
                text.enableWordWrapping = false;
                elements.Add(newElement);
            }
            for (int i = 0; i < elementValue.Length; i++) {
                content.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = elementValue[i];
            }
            rawDistance = new float[elements.Count];
            absDistance = rawDistance;
        }

        //FindClosestElement() and SnapToElement() inspiration from: Respect Studios - https://www.youtube.com/watch?v=jWbAaBEQpvE
        void FindClosestElement() {
            var minDistance = Mathf.Min(absDistance);
            for (int i = 0; i < elements.Count; i++) {
                rawDistance[i] = center.transform.position.y - elements[i].transform.position.y;
                absDistance[i] = Mathf.Abs(rawDistance[i]);
                
                if (Math.Abs(minDistance - absDistance[i]) < 0.01f) 
                    closestElement = i;
            }
            SnapToElement(-elements[closestElement].GetComponent<RectTransform>().anchoredPosition.y);
        }
        void SnapToElement(float pos) {
            if (scrolling) return;
            var newY = Mathf.Lerp(content.anchoredPosition.y, pos, Time.deltaTime * snapMultiplier);
            var newPos = new Vector2(0, newY);
            content.anchoredPosition = newPos;
        }

        public void OnBeginDrag(PointerEventData eventData) {
            scrolling = true;
            Debug.Log("a");
        }

        public void OnEndDrag(PointerEventData eventData) {
            scrolling = false;
            Debug.Log("b");
        }
    }
}
