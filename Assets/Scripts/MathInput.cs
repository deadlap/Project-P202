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
            output += _selected.elementInfo;
        }
    }

    public void Send(){
        print(output);
        // if (output.Length > 1) {
        display.AddTerm(output);
        // }
    }
}