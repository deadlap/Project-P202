using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Project-P202/Level", order = 0)]
public class Level : ScriptableObject {
    [SerializeField] public EquationLevel equationToLoad;
    public EquationLevel equation {get; private set;}
    [SerializeField] public List<string> numbersForScale;
    [SerializeField] public string xValue;
    public bool unlocked;
    public bool completed;
    public int score;

    [SerializeField] public static List<int> DefaultStepsPerStar = new List<int>() {4,8};

    void Awake() {
        DontDestroyOnLoad(this);
    }

    void OnEnable() {
        if (equation == null && numbersForScale.Count == 0) {
            equation = Instantiate(equationToLoad);
        }
    }

    public void SetEquation(Equation _equation){
        equation = EquationLevel.CreateEquationLevel(_equation, DefaultStepsPerStar);
    }

    public void ResetLevel(){
        if (numbersForScale.Count == 0)
            equation.ResetLevel();
        else
            equation = null;
    }
    public void Complete(){
        completed = true;
        SetScore();
    }
    public void SetScore(){
        if (equation == null) {
            return;
        }
        int newScore = equation.CalculateScore();
        if (newScore > score) {
            score = newScore;
        }
    }
}