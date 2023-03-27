using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class EquationDisplay : MonoBehaviour {
    [SerializeField] EquationLevel equationLevel;
    [SerializeField] TextMeshProUGUI leftText;
    [SerializeField] TextMeshProUGUI rightText;
    
    void Start(){
        equationLevel = Instantiate(equationLevel);
        equationLevel.ConvertToText();
        UpdateText();
    }
    
    void UpdateText(){
        leftText.text = equationLevel.eqToDisplay[0];
        rightText.text = equationLevel.eqToDisplay[1];
    }
        

    public EquationLevel Apply(string[] input){
        EquationLevel _temp = equationLevel;
        equationLevel = Instantiate(equationLevel);
        equationLevel.Apply(
            input[0],
            Convert.ToDouble(input[1]),
            input[2].Contains("x"));
        equationLevel.ConvertToText();
        equationLevel.SetPrevious(_temp);
        UpdateText();
        return equationLevel;
    }
    
    public bool Previous(){
        if (equationLevel.previous != null){
            equationLevel = equationLevel.previous;
            UpdateText();
            return true;
        }
        return false;
    }

    public void SetActiveDisplay(EquationLevel _equation) {
        equationLevel = _equation;
    }
}