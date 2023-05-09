using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ValueOfX : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField] string xText;
    [SerializeField] float transformationTime;
    public static string xValue;
    bool hasChanged;
    

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = xText;
    }
    void Start() {
        if (xValue == "") {
            int newXValue = Random.Range(1, 9);
            xValue = newXValue.ToString();
        }
    }
    void Update()
    {
        if(Time.timeScale == 0) return;
        StartCoroutine(ChangeLetter());
    }

    IEnumerator ChangeLetter()
    {
        yield return new WaitForSeconds(1f);
        if (hasChanged) yield break;
        var localScale = transform.localScale;
        if (text.text == xText)
        {
            var newScaleShrink = Mathf.Lerp(localScale.x, 0f, Time.deltaTime * transformationTime);
            var newScale = new Vector3(newScaleShrink, localScale.y, localScale.z);
            localScale = newScale;
            transform.localScale = localScale;
            if (Math.Abs(transform.localScale.x) > .001f) yield break;
            text.text = xValue;
        }

        var newScaleGrow = Mathf.Lerp(localScale.x, 1f, Time.deltaTime * transformationTime);
        var finalScale = new Vector3(newScaleGrow, localScale.y, localScale.z);
        transform.localScale = finalScale;
        if (Math.Abs(transform.localScale.x - 1f) > .001f) yield break;
        hasChanged = true;
    }
}
