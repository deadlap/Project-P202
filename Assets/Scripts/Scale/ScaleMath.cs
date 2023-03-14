using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScaleMath : MonoBehaviour
{
    TextMeshProUGUI thisText;
    [SerializeField] TextMeshProUGUI numberValueOne;
    [SerializeField] TextMeshProUGUI xValue;
    [SerializeField] TextMeshProUGUI signValue;
    [SerializeField] TextMeshProUGUI numberValueTwo;

    void Awake()
    {
        thisText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {

    }
}
