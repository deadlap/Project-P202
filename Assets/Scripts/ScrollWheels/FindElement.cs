using TMPro;
using UnityEngine;

namespace ScrollWheels {
    public class FindElement : MonoBehaviour {

        TextMeshProUGUI text;
        float oldAlpha;
        public string elementInfo {get; private set;} = "";
        void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Element")) {
                elementInfo = other.gameObject.GetComponent<TextMeshProUGUI>().text;
                text = other.gameObject.GetComponent<TextMeshProUGUI>();
                oldAlpha = text.alpha;
                if (elementInfo == "_") {
                    elementInfo = "";
                }
                text.alpha = 1;
            }
        }

        void OnTriggerExit2D(Collider2D other) {
            if (other.gameObject.CompareTag("Element")) {
                text = other.gameObject.GetComponent<TextMeshProUGUI>();
                text.alpha = oldAlpha;
            }
        }
    }
}
