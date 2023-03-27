using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Equation {
    public double leftXTerm;
    public double leftTerm;
    public double rightXTerm;
    public double rightTerm;

    public Equation(List<double> _terms){
        leftXTerm = _terms[0];
        leftTerm = _terms[1];
        rightXTerm = _terms[2];
        rightTerm = _terms[3];
    }

    public Equation(double _leftXTerm, double _leftTerm, double _rightXTerm, double _rightTerm){
        leftXTerm = _leftXTerm;
        leftTerm = _leftTerm;
        rightXTerm = _rightXTerm;
        rightTerm = _rightTerm;
    }
    
    public void CopyVariables(Equation _instance){
        leftXTerm = _instance.leftXTerm;
        leftTerm = _instance.leftTerm;
        rightXTerm = _instance.rightXTerm;
        rightTerm = _instance.rightTerm;
    }
    public Equation Copy(){
        return new Equation(leftXTerm, leftTerm, rightXTerm, rightTerm);
    }
}