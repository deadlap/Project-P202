using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static Solver solver = new Solver();

    [SerializeField] Level level;
    [SerializeField] GameObject equationPrefab;
    [SerializeField] MathInput mathInput;
    public EquationDisplay equationDisplay;
    public string defaultLevel;

    void Awake() {
        if (CurrentLevel.levelName.Length == 0) {
            level = Instantiate(Resources.Load("Levels/" + defaultLevel) as Level);
            ChangeActiveEquation(0);
        } else {
            level = Instantiate(Resources.Load("Levels/" + CurrentLevel.levelName) as Level);
            ChangeActiveEquation(0);
        }
    }
    
    public void ChangeActiveEquation(int _index) {
        MathInput.equation = level.GetEquationLevel(_index);
    }
}