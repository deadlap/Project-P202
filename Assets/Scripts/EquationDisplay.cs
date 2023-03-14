using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EquationDisplay : MonoBehaviour {
    [SerializeField] EquationLevel equationLevel;
    [SerializeField] TextMeshProUGUI textField;
    
    void Start(){
        equationLevel = Instantiate(equationLevel);
        textField.text = equationLevel.eqToDisplay;
    }
    
    void Update() {
        textField.text = equationLevel.eqToDisplay;
    }

    public void AddTerm(string _term){
        EquationLevel _temp = equationLevel;
        equationLevel = Instantiate(equationLevel);
        equationLevel.AddTerm(_term);
        equationLevel.Shorten();
        equationLevel.ConvertToText();
        equationLevel.SetPrevious(_temp);
        textField.text = equationLevel.eqToDisplay;
    }
    
    public bool Previous(){
        if (equationLevel.previous != null){
            equationLevel = equationLevel.previous;
            textField.text = equationLevel.eqToDisplay;
            return true;
        }
        return false;
    }

    public void SetActiveDisplay(EquationLevel _equation) {
        equationLevel = _equation;
    }

    public void Reset() {
        while(Previous());
        textField.text = equationLevel.eqToDisplay;
    }
}