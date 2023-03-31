using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static Level level {get; private set;}
    [SerializeField] Level defaultLevel;
    [SerializeField] GameObject equationPrefab;
    [SerializeField] MathInput mathInput;
    public EquationDisplay equationDisplay;

    void Awake() {
        if (level == null) {
            level = Instantiate(defaultLevel);
            ChangeActiveEquation(0);
        } else {
            level = Instantiate(level);
            ChangeActiveEquation(0);
        }
    }
    
    public void ChangeActiveEquation(int _index) {
        MathInput.equation = level.GetEquationLevel(_index);
    }
}