using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using ScrollWheels;

public class MathInput : MonoBehaviour {
    
    [SerializeField] EquationDisplay display;
    [SerializeField] FindElement[] input;

    string output;

    private void FixedUpdate() {
        output = "";
        foreach (FindElement _selected in input) {
            // We check if we are trying to add the symbol x and if there is a number selected
            // If there is a number selected we add the '*' symbol
            if (_selected.elementInfo.Contains('x') && output.Length > 1) {
                output += "*";
            }
            // We insert the selected symbol onto our output string.
            output += _selected.elementInfo;
        }
    }

    public void Send(){
        display.AddTerm(output);
    }
}