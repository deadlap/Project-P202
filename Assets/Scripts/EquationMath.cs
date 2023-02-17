using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EquationMath {
    public List<string> left;
    public List<string> right;
    public EquationMath(List<string> _left, List<string> _right){
        left = _left;
        right = _right;
    }
    public void CopyVariables(EquationMath _instance){
        left = _instance.left;
        right = _instance.right;
    }
}