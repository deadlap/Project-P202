using System;
using TMPro;
using UnityEngine;

namespace ScrollWheels
{
    public class FindElement : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI textField;

        TextMeshProUGUI text;
        string elementInfo;
        void Update()
        {
            
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Element"))
            {
                elementInfo = other.gameObject.GetComponent<TextMeshProUGUI>().text;
                text = other.gameObject.GetComponent<TextMeshProUGUI>();
                if (elementInfo == "...")
                {
                    elementInfo = "";
                }
                text.color = Color.black;
                textField.text = elementInfo;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Element"))
            {
                text = other.gameObject.GetComponent<TextMeshProUGUI>();
                text.color = Color.grey;
            }
        }
    }
}
