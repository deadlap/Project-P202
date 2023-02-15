using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equation", menuName = "Project-P202/Equation", order = 0)]
public class Equation : ScriptableObject {
    
    [SerializeField] EquationMath equationMath;
    [SerializeField] string solution;

    [SerializeField] public string eqToDisplay {get; private set;}
    
    [SerializeField] public Equation previous {get; private set;}

    public Equation(string _eqLeft, string _eqRight, string _solution){
        equationMath = new EquationMath(_eqLeft, _eqRight);
        solution = _solution;
    }

    private void Awake() {
        ConvertToText();
    }

    public void ConvertToText(){
        eqToDisplay = equationMath.left + " = " + equationMath.right;
    }

    public void AddTerm(string _term){
        previous = Instantiate(this);
        equationMath.left += _term;
        equationMath.right += _term;
        ConvertToText();
    }
    public void SetPrevious() {

    }
}
