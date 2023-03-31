using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour {
    public static Level level {get; private set;}
    [SerializeField] Level defaultLevel;
    [SerializeField] MathInput mathInput;
    [SerializeField] EquationDisplay equationDisplay;
    [SerializeField] List<TextMeshProUGUI> equationOutputs;
    int currentIndex = 0;

    void Awake() {
        if (level == null) {
            level = Instantiate(defaultLevel);
        } else {
            level = Instantiate(level);
        }
        MathInput.equation = level.GetEquationLevel(currentIndex);
        mathInput.SetActiveEquation();
    }

    public void DisableEquationButton(int _index){
        equationOutputs[_index].transform.GetComponent<Button>().gameObject.SetActive(false);
    }
    
    void Update() {
        for (int i = 0; i < equationOutputs.Count; i++) {
            if (level.GetEquationLevel(i).Solved(out double solution)) {
                DisableEquationButton(i);
                equationOutputs[i].text = ""+solution;
            }
        }
    }

    public void ChangeActiveEquation(int _index) {
        level.SetEquation(currentIndex, level.GetEquationLevel(currentIndex));
        currentIndex = _index;
        MathInput.equation = level.GetEquationLevel(currentIndex);
        mathInput.SetActiveEquation();
        ToggleEquationDisplay();
    }

    public void ToggleEquationDisplay(){
        this.gameObject.SetActive(!this.gameObject.activeSelf);
        mathInput.gameObject.SetActive(!mathInput.gameObject.activeSelf);
        equationDisplay.gameObject.SetActive(!equationDisplay.gameObject.activeSelf);
    }

}