using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentLevel", menuName = "Project-P202/CurrentLevel", order = 0)]
public class CurrentLevel : ScriptableObject {
    [SerializeField] public static string levelName {get; private set;} = "";
    
    public void SetLevel(string _levelName){
        levelName = _levelName;
    }
}
