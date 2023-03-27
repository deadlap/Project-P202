using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScaleMath : MonoBehaviour {
    TextMeshProUGUI sumText;
    [SerializeField] TextMeshProUGUI numberValueOne;
    [SerializeField] TextMeshProUGUI xValue;
    [SerializeField] TextMeshProUGUI signValue;
    [SerializeField] TextMeshProUGUI numberValueTwo;
    void Awake(){
        sumText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update(){
        if (CalculateSum(out double sum)) {
            if (sum % 1 != 0) {
                sumText.text = EquationLevel.ConvertToFraction(sum);
                return;
            }
            sumText.text = ""+sum;
        } else {
            sumText.text = "";
        }
    }
    
    bool ViableExpression(){
        return (HasItem(numberValueOne)&&HasItem(signValue)&&HasItem(numberValueTwo));
    }

    bool HasItem(TextMeshProUGUI textSlot){
        return !(String.IsNullOrEmpty(textSlot.text));
    }
    

    public bool CalculateSum(out double sum){
        sum = 0;
        if (!ViableExpression())
            return false;
        sum += Convert.ToDouble(numberValueOne.text)*Convert.ToDouble(xValue.text);
        switch (signValue.text){
            case "+":
                sum += Convert.ToDouble(numberValueTwo.text);
                break;
            case "-":
                sum -= Convert.ToDouble(numberValueTwo.text);
                break;
            case "*":
                sum *= Convert.ToDouble(numberValueTwo.text);
                break;
            case "/":
                sum /= Convert.ToDouble(numberValueTwo.text);
                break;
        }
        return true;
    }

    public void returnTerms(out double xTerm, out double term){
        xTerm = 0;
        term = 0;
        switch (signValue.text){
            case "+":
                xTerm = Convert.ToDouble(numberValueOne.text);
                term = Convert.ToDouble(numberValueTwo.text);
                break;
            case "-":
                xTerm = Convert.ToDouble(numberValueOne.text);
                term = -1 * Convert.ToDouble(numberValueTwo.text);
                break;
            case "*":
            case "/":
                CalculateSum(out double sum);
                xTerm = sum;
                break;
        }
    }
}
