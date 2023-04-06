using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static Level ActiveLevel {get; private set;}
    [SerializeField] Level defaultLevel;
    [SerializeField] MathInput mathInput;
    [SerializeField] EquationDisplay equationDisplay;
    [SerializeField] GenerateDraggableItem numberGenerator;

    void Awake() {
        if (ActiveLevel == null) {
            ActiveLevel = Instantiate(defaultLevel);
        } else {
            ActiveLevel = Instantiate(ActiveLevel);
        }

        if (ActiveLevel.equation){
            MathInput.equation = ActiveLevel.equation;
            mathInput.SetActiveEquation();
        } else {
            numberGenerator.numberInItem = ActiveLevel.numbersForScale;
        }
        
    }

    public static void SetActiveLevel(Level _level) {
        ActiveLevel = _level;
    }
}