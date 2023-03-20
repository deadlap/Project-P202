using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;

public class ScaleMath : MonoBehaviour
{
    TextMeshProUGUI sumText;
    [SerializeField] TextMeshProUGUI numberValueOne;
    [SerializeField] TextMeshProUGUI xValue;
    [SerializeField] TextMeshProUGUI signValue;
    [SerializeField] TextMeshProUGUI numberValueTwo;
    int charAmount = 5; // ___________ Find bedre navn maybe?
    // Is the amount of chars needed for all 
    void Awake(){
        sumText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update(){
        if (CalculateSum(out float sum)) {
            sumText.text = ""+sum;
        } else {
            sumText.text = "";
        }
    }
    
    // returns false if length of the strings combined,
    // is less than what is required for each slot to be filled out, plus the '*' char
    public bool CalculateSum(out float sum){
        sum = 0;
        string calculation = numberValueOne.text+"*"+xValue.text+signValue.text+numberValueTwo.text;
        if (calculation.Length < charAmount)
            return false;
        Solver.Evaluate(calculation, out float _sum);
        sum = _sum;
        return true;
    }
}
