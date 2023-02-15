using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EquationMath {
    public string left;
    public string right;
    public EquationMath(string _Item1, string _Item2){
        left = _Item1;
        right = _Item2;
    }
}