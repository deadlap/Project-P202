using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EquationDisplay : MonoBehaviour {
    [SerializeField] Equation equation;
    [SerializeField] TextMeshProUGUI textField;
    
    void Start(){
        equation = Instantiate(equation);
        textField.text = equation.eqToDisplay;
    }
    
    // void Update() {
    //     textField.text = equation.eqToDisplay;
    // }

    public void AddTerm(string _term){
        equation.AddTerm(_term);
        textField.text = equation.eqToDisplay;
    }
    
    public void Previous(){
        if (equation.previous != null){
            equation = equation.previous;
            textField.text = equation.eqToDisplay;
        }
    }
}