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
        EquationLevel _temp = equationLevel;
        equationLevel = Instantiate(equationLevel);
        equationLevel.Apply(
            input[0],
            Convert.ToDouble(input[1]),
            input[2].Contains("x"));
        equationLevel.SetPrevious(_temp);
        return equationLevel;
    }
    
    public bool Previous(){
        return equationLevel.Previous();
    }

    public void SetActiveEquation(EquationLevel _equation) {
        equationLevel = _equation;
    }
}