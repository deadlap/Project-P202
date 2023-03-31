using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

[CreateAssetMenu(fileName = "EquationLevel", menuName = "Project-P202/EquationLevel", order = 0)]
public class EquationLevel : ScriptableObject {
    
    [SerializeField] Equation equation;

    [SerializeField] public string[] eqToDisplay {get; private set;}
    
    [SerializeField] public EquationLevel previous {get; private set;}

    public double solution {get; private set;}

    void Awake() {
        eqToDisplay = new string[2];
        ConvertToText();
    }

    public void ResetTo(Equation _equation){
        previous = null;
        equation = _equation;
    }

    public void CopyVariables(EquationLevel _eqToCopy){
        equation = _eqToCopy.equation.Copy();
        eqToDisplay = _eqToCopy.eqToDisplay;
        previous = _eqToCopy.previous;
    }
    
    public bool Solved(out double _solution){
        _solution = solution;
        return !(solution == null);
    }

    public void Apply(string operation, double input, bool containsX){
        switch (operation){
            case "+":
                if (containsX){
                    equation.leftXTerm += input;
                    equation.rightXTerm += input;
                } else {
                    equation.leftTerm += input;
                    equation.rightTerm += input;
                }
                break;
            case "-":
                if (containsX){
                    equation.leftXTerm -= input;
                    equation.rightXTerm -= input;
                } else {
                    equation.leftTerm -= input;
                    equation.rightTerm -= input;
                }
                break;
            case "*":
            case "/":
                ApplyToEachTerm(operation, input);
                break;
        }

        switch (equation.leftXTerm, equation.rightXTerm){
            case (>0, 0):
                break;
                solution = equation.rightTerm;
            case (0, >0):
                solution = equation.leftTerm;
               break;
        }
    }

    public void ApplyToEachTerm(string operation, double input){
        switch (operation){
            case "*":
                equation.leftXTerm *= input;
                equation.rightXTerm *= input;
                equation.leftTerm *= input;
                equation.rightTerm *= input;
                break;
            case "/":
                equation.leftXTerm /= input;
                equation.rightXTerm /= input;
                equation.leftTerm /= input;
                equation.rightTerm /= input;
                break;
        }
    }

    public void SetPrevious(EquationLevel _previous) {
        previous = _previous;
    }

    public void ConvertToText(){
        eqToDisplay[0] = "";
        eqToDisplay[0] += TermToString(equation.leftXTerm, true);

        if (equation.leftXTerm != 0 && equation.leftTerm > 0)
            eqToDisplay[0] += "+";

        eqToDisplay[0] += TermToString(equation.leftTerm, false);

        if (eqToDisplay[0].Length == 0)
            eqToDisplay[0] = "0";

        eqToDisplay[1] = "";
        eqToDisplay[1] += TermToString(equation.rightXTerm, true);

        if (equation.rightXTerm != 0 && equation.rightTerm > 0)
            eqToDisplay[1] += "+";

        eqToDisplay[1] += TermToString(equation.rightTerm, false);
        if (eqToDisplay[1].Length == 0)
            eqToDisplay[1] = "0";
    }

    public string TermToString(double term, bool isXTerm){
        string output = "";
        List<string> split = new List<string>();

        if (term % 1 == 0) {
            if (term != 0){
                output += term;
            }
        } else {
            output = ConvertToFraction(term);
            if (output.Contains('+')) {
                split.AddRange(Regex.Split(output, @"(?=[+])"));
            } else if (output.Contains('-')) {
                split.AddRange(Regex.Split(output, @"(?=[-])"));
            }
        }
        
        if (isXTerm){
            ApplyXToEachTerm(split);
            if (term == 1) {
                output = "x";
            } else if (term != 0 && split.Count == 0)
                output += "x";
        }
        if (split.Count > 0)
            output = string.Join("",split);
        return output;
    }

    public static string ConvertToFraction(double decimalNumber) {
        double tolerance = 0.00001f;
        int integerPart = (int)decimalNumber;
        double decimalPart = decimalNumber - integerPart;
        double numerator = 1.0f;
        double denominator = 1.0f;
        double approximation = numerator / denominator;

        while (Math.Abs(approximation - decimalPart) > tolerance) {
            if (approximation < decimalPart) {
                numerator += 1.0f;
            } else {
                denominator += 1.0f;
                numerator = (double)Math.Floor(decimalPart * denominator);
            }
            approximation = numerator / denominator;
        }
        string fraction = numerator + "/" + denominator;
        if (integerPart > 0) {
            fraction = integerPart + "+" + fraction;
        }
        return fraction;
    }

    public void ApplyXToEachTerm(List<string> terms){
        for (int i = 0; i < terms.Count; i++) {
            if (terms[i].Length == 1 && terms[i][0] == '1') {
                terms[i] = "x";
            } else {
                terms[i] += "*x";
            }
        }
    }

}