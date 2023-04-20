using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {
    static string EquationSceneName = "EquationRandom";
    static string ScaleSceneName = "Scale";

    public static void StaticChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public static void GoToCOOP(){
        LevelManager.RemoveActiveLevel();
        SceneManager.LoadScene(ScaleSceneName);
    }
    public void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    }
    public void EndGame() {
        Application.Quit();
    }
    public void ChangeToRandomEquation() {
        EquationLevel[] AllEquations =  (Resources.LoadAll<EquationLevel>("Equations/") as EquationLevel[]);
        MathInput.Equation = Instantiate(AllEquations[Random.Range(0,AllEquations.Length-1)]);
        SceneManager.LoadScene(EquationSceneName);
    }
    public static void ChangeToEquation(Equation equation) {
        EquationLevel eq = Instantiate(Resources.Load("CompleteEquation") as EquationLevel);
        eq.ResetTo(equation);
        MathInput.Equation = Instantiate(eq);
        SceneManager.LoadScene(EquationSceneName);
    }
    
    public static void GoToLevel(Level level) {
        LevelManager.SetActiveLevel(level);
        if (level.equation) {
            MathInput.Equation = level.equation;
            SceneManager.LoadScene(EquationSceneName);
        } else {
            SceneManager.LoadScene(ScaleSceneName);
        }
    }
}
