using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Level", menuName = "Project-P202/Level", order = 0)]
public class Level : ScriptableObject {
    [SerializeField] public EquationLevel equationToLoad;
    public EquationLevel equation {get; private set;}
    [SerializeField] public List<string> numbersForScale;
    [SerializeField] public string xValue;
    [SerializeField] public bool unlocked = false;
    [SerializeField] public int score;

    [SerializeField] public static List<int> DefaultStepsPerStar = new List<int>() {4,8};

    void OnEnable() {
        if (equation == null && numbersForScale.Count == 0) {
            Debug.Log("test");
            equation = Instantiate(equationToLoad);
        }
    }

    public void SetEquation(Equation _equation){
        equation = EquationLevel.CreateEquationLevel(_equation, DefaultStepsPerStar);
    }

    public int CalculateScore(){
        if (equation == null)
            return 0;
        return equation.CalculateScore();
    }
}