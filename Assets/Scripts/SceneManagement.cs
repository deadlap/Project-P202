using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {
    static string RandomEquationSceneName = "EquationRandom";
    public static void StaticChangeScene(string scene){
        SceneManager.LoadScene(scene);
    }
    public void ChangeScene(string scene){
        SceneManager.LoadScene(scene);
    }
    public void EndGame(){
        Application.Quit();
    }
    public void ChangeToRandomEquation(){
        EquationLevel[] AllEquations =  (Resources.LoadAll<EquationLevel>("Equations/") as EquationLevel[]);
        MathInput.equation = Instantiate(AllEquations[Random.Range(0,AllEquations.Length-1)]);
        SceneManager.LoadScene(RandomEquationSceneName);
    }
    public static void ChangeToEquation(Equation equation){
        EquationLevel eq = Instantiate(Resources.Load("CompleteEquation") as EquationLevel);
        eq.ResetTo(equation);
        MathInput.equation = Instantiate(eq);
        SceneManager.LoadScene(RandomEquationSceneName);
    }
}
