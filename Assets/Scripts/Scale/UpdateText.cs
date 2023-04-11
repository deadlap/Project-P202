using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour {
    [SerializeField] TextMeshProUGUI textToMimic;
    TextMeshProUGUI thisText;
    // Start is called before the first frame update
    void Start() {
        thisText = GetComponent<TextMeshProUGUI>();
        thisText.text = textToMimic.text;
    }
}
