using TMPro;
using UnityEngine;

public class ValueOfX : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI xLeftText;
    [SerializeField] TextMeshProUGUI xRightText;
    [SerializeField] string xValue;
    void Awake() {
        if (xValue == "") {
            int newXValue = Random.Range(1, 9);
            xLeftText.text = newXValue.ToString();
            xRightText.text = newXValue.ToString();
        }
        else {
            string newXValue = xValue;
            xLeftText.text = newXValue;
            xRightText.text = newXValue;
        }
    }
}
