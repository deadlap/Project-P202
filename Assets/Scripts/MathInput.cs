using UnityEngine;
using ScrollWheels;

public class MathInput : MonoBehaviour {
    public static EquationLevel equation;
    [SerializeField] EquationDisplay display;
    [SerializeField] FindElement[] input;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource source;
    string output;

    void Start() {
        display.SetActiveDisplay(equation);
    }

    void FixedUpdate() {
        output = "";
        foreach (FindElement _selected in input) {
            // We check if we are trying to add the symbol x and if there is a number selected
            // If there is a number selected we add the '*' symbol
            if (_selected.elementInfo.Contains("x") && output.Length > 1) {
                output += "*";
            }
            // We insert the selected symbol onto our output string.
            output += _selected.elementInfo;
        }
    }

    public void Send(){
        if (output.Contains("x") && !(output.Contains("+") || output.Contains("-"))) {
            print(output);
            animator.Play("ErrorOnSign");
            source.Play();
        } else if (output.Length == 1) {
            animator.SetTrigger("ErrorOnValues");
            source.Play();
        } else {
            equation = display.AddTerm(output);
        }
    }
    public void Undo(){
        display.Previous();
    }

    public void Reset() {
        while(display.Previous());
    }
}