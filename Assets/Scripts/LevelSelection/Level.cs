using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Project-P202/Level", order = 0)]
public class Level : ScriptableObject {
    [SerializeField] List<EquationLevel> equations;
    public string solution {get; private set;} = "";
    
    void Awake(){
        for (int i = 0; i < equations.Count; i++) {
            equations[i] = Instantiate(equations[i]);
        }
        foreach (EquationLevel _equation in equations) {
            solution += _equation.solution;
        }
    }

    public EquationLevel GetEquationLevel(int _index) {
        return equations[_index];
    }
}