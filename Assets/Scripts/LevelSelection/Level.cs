using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Level", menuName = "Project-P202/Level", order = 0)]
public class Level : ScriptableObject {
    [SerializeField] public string equationToLoad;
    [SerializeField] public EquationLevel equation {get; private set;}
    [SerializeField] public List<string> numbersForScale;
    [SerializeField] public string xValue;
    [SerializeField] public bool unlocked = false;
    [SerializeField] public int score;

    [SerializeField] public static List<int> DefaultStepsPerStar = new List<int>() {4,8};

    void OnEnable() {
        if (numbersForScale.Count == 0) {
            equation = Instantiate(Resources.Load("Equations/"+equationToLoad) as EquationLevel);
        }
    }

    public void SetEquation(Equation _equation){
        equation = EquationLevel.CreateEquationLevel(_equation, DefaultStepsPerStar);
    }

    public int CalculateScore(){
        if (equation == null || !equation.Solution(out _))
            return 0;
        switch(equation.steps) {
            case var _ when equation.steps>equation.stepsPerStar[1]:
                return 1;
            case var _ when equation.steps>equation.stepsPerStar[0]:
                return 2;
            case var _ when equation.steps>0:
                return 3;
            default:
                return 0;
        }
    }
}