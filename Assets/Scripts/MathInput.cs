using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MathInput : MonoBehaviour {
    string output;
    [SerializeField] EquationDisplay display;
    [SerializeField] TextMeshProUGUI textField;

    public void Insert(string input){
        output += input;
        UpdateText();
    }

    public void InsertAndSend(string input){
        output = input+output;
        display.AddTerm(output);
        Clear();
        UpdateText();
    }

    public void Clear(){
        output = "";
        UpdateText();
    }
    
    public void UpdateText(){   
        textField.text = output;
    }
}