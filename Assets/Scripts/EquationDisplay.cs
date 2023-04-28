using UnityEngine;
using TMPro;
using System;

public class EquationDisplay : MonoBehaviour {
    public EquationLevel equationLevel {get; private set;}
    [SerializeField] TextMeshProUGUI leftText;
    [SerializeField] TextMeshProUGUI rightText;
    
    void UpdateText(){
        equationLevel.ConvertToText();
        leftText.text = equationLevel.LeftText();
        rightText.text = equationLevel.RightText();
    }
    
    void Update(){
        UpdateText();
    }

    public EquationLevel Apply(string[] input){
        EquationLevel _temp = Instantiate(equationLevel);
        _temp.CopyVariables(equationLevel);
        equationLevel.SetPrevious(_temp);
        equationLevel.Apply(
            input[0],
            Convert.ToDouble(input[1]),
            input[2].Contains("x"));
        return equationLevel;
    }
    
    public void Previous(){
        equationLevel.Previous();
    }

    public void SetActiveEquation(EquationLevel _equation) {
        equationLevel = _equation;
    }
}