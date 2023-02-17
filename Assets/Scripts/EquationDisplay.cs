using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EquationDisplay : MonoBehaviour {
    [SerializeField] Equation equation;
    [SerializeField] TextMeshProUGUI textField;
    [SerializeField] Equation ogEquation;

    void Start(){
        ogEquation = equation;
        equation = Instantiate(equation);
        textField.text = equation.eqToDisplay;
    }
    
    void Update() {
        textField.text = equation.eqToDisplay;
    }

    public void AddTerm(string _term){
        Equation _temp = equation;
        equation = Instantiate(equation);
        equation.AddTerm(_term);
        equation.SetPrevious(_temp);
        equation.Shorten();
        textField.text = equation.eqToDisplay;
    }
    
    public void Previous(){
        if (equation.previous != null){
            equation = equation.previous;
            textField.text = equation.eqToDisplay;
        }
    }
    public void Reset() {
        equation = Instantiate(ogEquation);
        textField.text = equation.eqToDisplay;
    }

    
}