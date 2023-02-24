using System;
using TMPro;
using UnityEngine;

namespace ScrollWheels {
    public class FindElement : MonoBehaviour {

        TextMeshProUGUI text;
        public string elementInfo {get; private set;} = "";
        Color defaultColor = Color.grey;

        void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Element")) {
                elementInfo = other.gameObject.GetComponent<TextMeshProUGUI>().text;
                text = other.gameObject.GetComponent<TextMeshProUGUI>();
                if (elementInfo == "...") {
                    elementInfo = "";
                }
                text.color = Color.black;
            }
        }

        void OnTriggerExit2D(Collider2D other) {
            if (other.gameObject.CompareTag("Element")) {
                text = other.gameObject.GetComponent<TextMeshProUGUI>();
                text.color = defaultColor;
            }
        }

        public void SetColor(Color newColor) {
            text.color = newColor;
        }

        public void ResetColor() {
            text.color = default;
        }
    }
}
