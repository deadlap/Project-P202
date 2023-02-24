using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement {
    public static void ChangeScene(string scene){
        SceneManager.LoadScene(scene);
    }
    public static void EndGame(){
        Application.Quit();
    }
}
