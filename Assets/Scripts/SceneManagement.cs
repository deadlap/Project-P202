using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {
    string RandomEquationSceneName = "EquationRandom";
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
}
