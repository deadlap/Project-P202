using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static Solver solver = new Solver();
    // {get; private set;}
    [SerializeField] Level level;
    [SerializeField] GameObject EquationPrefab; 
    public List<EquationDisplay> equationDisplays;
    void Awake() {
        level = Instantiate(Resources.Load("Levels/" + CurrentLevel.levelName) as Level);
        CreateEquationDisplays();
    }

    void CreateEquationDisplays() {
        GameObject _temp = Instantiate(EquationPrefab, this.transform);
        // _temp.transform.SetParent(this.transform);
        equationDisplays.Add(_temp.transform.GetComponentInChildren<EquationDisplay>());
    }
}
