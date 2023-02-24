using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour {
    [SerializeField] CurrentLevel levelObject;

    public void GoToLevel(string nextLevel){
        levelObject.SetLevel(nextLevel);
        SceneManagement.ChangeScene("SampleScene");
    }
}
