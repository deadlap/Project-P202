using TMPro;
using UnityEngine;

public class ValueOfX : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI xLeftText;
    [SerializeField] TextMeshProUGUI xRightText;
    void Awake() {
        int xValue = Random.Range(1, 9);
        xLeftText.text = xValue.ToString();
        xRightText.text = xValue.ToString();
    }
}
