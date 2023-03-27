using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Project-P202/Level", order = 0)]
public class Level : ScriptableObject {
    [SerializeField] List<EquationLevel> equations;
        
    void Awake(){
        for (int i = 0; i < equations.Count; i++) {
            equations[i] = Instantiate(equations[i]);
        }
    }

    public EquationLevel GetEquationLevel(int _index) {
        return equations[_index];
    }
}