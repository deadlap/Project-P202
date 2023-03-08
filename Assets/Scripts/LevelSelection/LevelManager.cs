using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static Solver solver = new Solver();
    // {get; private set;}
    [SerializeField] Level level;
    [SerializeField] GameObject equationPrefab; 
    public List<EquationDisplay> equationDisplays;
    public string defaultLevel;
    void Awake() {
        if (CurrentLevel.levelName.Length == 0) {
            level = Instantiate(Resources.Load("Levels/" + defaultLevel) as Level);
        } else {
            level = Instantiate(Resources.Load("Levels/" + CurrentLevel.levelName) as Level);   
        }
        CreateEquationDisplays();
    }

    void CreateEquationDisplays() {
        GameObject _temp = Instantiate(equationPrefab, this.transform);
        // _temp.transform.SetParent(this.transform);
        equationDisplays.Add(_temp.transform.GetComponentInChildren<EquationDisplay>());
    }
}
