using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using ScrollWheels;

public class MathInput : MonoBehaviour {
    
    [SerializeField] EquationDisplay display;
    [SerializeField] FindElement[] input;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource source;
    string output;

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
            display.AddTerm(output);
        }
    }
}