using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour {
    [SerializeField] Level levelObject;

    public void GoToLevel(){
        LevelManager.SetActiveLevel(levelObject);
    }
}