using TMPro;
using UnityEngine;

public class ValueOfX : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI xText;
    void Awake()
    {
        int xValue = Random.Range(1, 9);
        xText.text = xValue.ToString();
    }
}
