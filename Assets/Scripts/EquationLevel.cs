using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "EquationLevel", menuName = "Project-P202/EquationLevel", order = 0)]
public class EquationLevel : ScriptableObject {
    
    [SerializeField] Equation equation;
    [SerializeField] public string solution {get; private set;}

    [SerializeField] public string eqToDisplay {get; private set;}
    
    [SerializeField] public EquationLevel previous {get; private set;}

    public EquationLevel(List<string> _eqLeft, List<string> _eqRight, string _solution){
        equation = new Equation(_eqLeft, _eqRight);
        solution = _solution;
    }

    void Awake() {
        ConvertToText();
    }

    public void CopyVariables(EquationLevel _eqToCopy){
        equation = new Equation(_eqToCopy.equation.left, _eqToCopy.equation.right);
        solution = _eqToCopy.solution;
        eqToDisplay = _eqToCopy.eqToDisplay;
        previous = _eqToCopy.previous;
    }

    public void ConvertToText(){
        eqToDisplay = "";
        foreach(string _term in equation.left)
            eqToDisplay += _term;
        
        eqToDisplay += " = ";
        
        foreach(string _term in equation.right)
            eqToDisplay += _term;
    }

    public void AddTerm(string _term){
        switch (_term[0]){
            case '+':
            case '-':
                equation.left.Add(_term);
                equation.right.Add(_term);
                break;
            case '*':
            case '/':
                ApplyToEachTerm(_term);
                break;
        }
    }

    public void Shorten(){
        equation.left = LevelManager.solver.Shorten(equation.left);
        equation.right = LevelManager.solver.Shorten(equation.right);

    }

    public void SetPrevious(EquationLevel _previous) {
        previous = _previous;
    }

    public void ApplyToEachTerm(string _input){
        for (int i = 0; i < equation.left.Count; i++) {
            equation.left[i] += _input;
        }
        for (int i = 0; i < equation.right.Count; i++) {
            equation.right[i] += _input;            
        }
    }
}
