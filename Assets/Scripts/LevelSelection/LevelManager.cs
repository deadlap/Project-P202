using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public static Level ActiveLevel {get; private set;}
    [SerializeField] Level defaultLevel;
    [SerializeField] MathInput mathInput;
    [SerializeField] GameObject returnButton;
    [SerializeField] EquationDisplay equationDisplay;
    [SerializeField] List<TextMeshProUGUI> equationOutputs;
    public bool displayIsActive;
    int currentIndex = 0;

    void Awake() {
        displayIsActive = false;
        if (ActiveLevel == null) {
            ActiveLevel = Instantiate(defaultLevel);
        } else {
            ActiveLevel = Instantiate(ActiveLevel);
        }
        MathInput.equation = ActiveLevel.GetEquationLevel(currentIndex);
        mathInput.SetActiveEquation();
    }

    public void DisableEquationButton(int _index) {
        equationOutputs[_index].transform.parent.gameObject.GetComponent<Button>().enabled = false;
    }
    
    void Update() {
        if (displayIsActive && MathInput.equation.Solution(out double _solution)) {
            ToggleEquationDisplay();
            DisableEquationButton(currentIndex);
            equationOutputs[currentIndex].text = ""+_solution;
        }
    }

    public void ChangeActiveEquation(int _index) {
        if (_index == -1)
            _index = currentIndex;
        ActiveLevel.SetEquation(currentIndex, MathInput.equation);
        currentIndex = _index;
        MathInput.equation = ActiveLevel.GetEquationLevel(currentIndex);
        mathInput.SetActiveEquation();
        ToggleEquationDisplay();
    }

    public void ToggleEquationDisplay() {
        displayIsActive = !displayIsActive;
        this.transform.GetChild(0).gameObject.SetActive(!displayIsActive);
        mathInput.gameObject.SetActive(displayIsActive);
        equationDisplay.gameObject.SetActive(displayIsActive);
        returnButton.SetActive(displayIsActive);
    }

    public static void SetActiveLevel(Level _level) {
        ActiveLevel = _level;
    }
}