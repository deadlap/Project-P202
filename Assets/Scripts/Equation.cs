using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Equation {
    public List<string> left;
    public List<string> right;
    public Equation(List<string> _left, List<string> _right){
        left = _left;
        right = _right;
    }
    public void CopyVariables(Equation _instance){
        left = _instance.left;
        right = _instance.right;
    }
}