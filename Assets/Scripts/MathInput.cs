using UnityEngine;
using ScrollWheels;
using System;
using System.Collections.Generic;

public class MathInput : MonoBehaviour {
    public static EquationLevel equation;
    [SerializeField] EquationDisplay display;
    [SerializeField] FindElement[] input;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource errorSource;
    string[] output;

    void Awake() {
        SetActiveEquation();
        output = new string[3];
    }

    void FixedUpdate() {
        output = new string[3];
        for (int i = 0; i < input.Length; i++) {
            output[i] = input[i].elementInfo;
        }
    }

    public void Send() {
        if (ViableOutput()) {
            equation = display.Apply(output);
        }
    }

    public bool ViableOutput(){
        if (output[2].Contains("x")  && !(output[0].Contains('+') || output[0].Contains('-'))) {
            animator.Play("ErrorOnSign");
            errorSource.Play();
            return false;
        } else if (String.Join("", output).Length == 1) {
            animator.SetTrigger("ErrorOnValues");
            errorSource.Play();
            return false;
        }
        if (output[1].Length == 0)
            output[1] = "1";
        return true;
    }

    public void SetActiveEquation(){
        display.SetActiveEquation(equation);
    }

    public void Undo(){
        display.Previous();
    }

    public void Reset() {
        equation.Reset();
    }
}