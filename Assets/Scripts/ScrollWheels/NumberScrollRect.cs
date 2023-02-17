using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberScrollRect : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] float itemSize;
    [SerializeField] float itemSpace;

    [SerializeField] List<string> numbers;

        void Start()
        {
            foreach (string number in numbers)
            {
                GameObject item = new("Item");
                item.transform.SetParent(content.transform);
                item.transform.localScale = new Vector3(itemSize, itemSize, 0);

                TextMeshProUGUI text = item.AddComponent<TextMeshProUGUI>();
                text.color = Color.black;
                text.autoSizeTextContainer = true;
            }
    
            content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, numbers.Count * itemSpace);
        }
    
        void Update()
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                content.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = numbers[i];
            }
        }
}
