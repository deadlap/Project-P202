using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Project-P202/Level", order = 0)]
public class Level : ScriptableObject {
    [SerializeField] public EquationLevel equation;
    [SerializeField] public List<string> numbersForScale;

    void Awake(){
        // equation = Instantiate(equation);
    }

    public void SetEquation(EquationLevel _equation) {
        equation = _equation;
    }
}