using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {
    public static void StaticChangeScene(string scene){
        SceneManager.LoadScene(scene);
    }
    public void ChangeScene(string scene){
        SceneManager.LoadScene(scene);
    }
    public void EndGame(){
        Application.Quit();
    }
}
