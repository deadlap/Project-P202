using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;

public class ScaleCombine : MonoBehaviour {
    [SerializeField] ScaleMath left;
    [SerializeField] ScaleMath right;
    [SerializeField] GameObject finishButton;
    void Start(){
        finishButton.SetActive(false);
    }

    void Update(){
        if(left.CalculateSum(out double leftSum) && right.CalculateSum(out double rightSum)) {
            finishButton.SetActive(leftSum == rightSum);
        }
    }

    public void CreateEquation(){
        left.returnTerms(out double _leftXTerm, out double leftTerm);
        right.returnTerms(out double _rightXTerm, out double rightTerm);
        Equation equation = new Equation(_leftXTerm, leftTerm, _rightXTerm, rightTerm);
        SceneManagement.ChangeToEquation(equation);
    }



}
