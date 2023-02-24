using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Equation", menuName = "Project-P202/Equation", order = 0)]
public class Equation : ScriptableObject {
    
    [SerializeField] EquationMath equationMath;
    [SerializeField] public string solution {get; private set;}

    [SerializeField] public string eqToDisplay {get; private set;}
    
    [SerializeField] public Equation previous {get; private set;}

    public Equation(List<string> _eqLeft, List<string> _eqRight, string _solution){
        equationMath = new EquationMath(_eqLeft, _eqRight);
        solution = _solution;
    }

    private void Awake() {
        ConvertToText();
    }

    public void CopyVariables(Equation _eqToCopy){
        equationMath = new EquationMath(_eqToCopy.equationMath.left, _eqToCopy.equationMath.right);
        solution = _eqToCopy.solution;
        eqToDisplay = _eqToCopy.eqToDisplay;
        previous = _eqToCopy.previous;
    }

    public void ConvertToText(){
        eqToDisplay = "";
        foreach(string _term in equationMath.left)
            eqToDisplay += _term;
        
        eqToDisplay += " = ";
        
        foreach(string _term in equationMath.right)
            eqToDisplay += _term;
    }

    public void AddTerm(string _term){
        switch (_term[0]){
            case '+':
            case '-':
                equationMath.left.Add(_term);
                equationMath.right.Add(_term);
                break;
            case '*':
            case '/':
                ApplyToEachTerm(_term);
                break;
        }
        equationMath.left = LevelManager.solver.Shorten(equationMath.left);
        equationMath.right = LevelManager.solver.Shorten(equationMath.right);
        ConvertToText();
    }

    public void SetPrevious(Equation _previous) {
        previous = _previous;
    }

    public void Shorten(){
        
    }

    public void ApplyToEachTerm(string _input){
        for (int i = 0; i < equationMath.left.Count; i++) {
            equationMath.left[i] += _input;
        }
        for (int i = 0; i < equationMath.right.Count; i++) {
            equationMath.right[i] += _input;            
        }
    }
}
