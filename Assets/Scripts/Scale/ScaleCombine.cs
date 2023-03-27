using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScaleCombine : MonoBehaviour {
    [SerializeField] ScaleMath left;
    [SerializeField] ScaleMath right;
    [SerializeField] GameObject pole;
    [SerializeField] GameObject finishButton;
    [SerializeField] float rotationMax;

    void Start(){
        finishButton.SetActive(false);
    }

    void Update(){
        float curRotation = 0;
        float rotationOffset = 0;
        if(left.CalculateSum(out double leftSum) && right.CalculateSum(out double rightSum)) {
            finishButton.SetActive(leftSum == rightSum);
            curRotation = -rotationMax+(float)(leftSum/rightSum)*rotationMax;
            curRotation = (curRotation > rotationMax ? rotationMax : curRotation);
            curRotation = (curRotation < -rotationMax ? -rotationMax : curRotation);
            rotationOffset = -curRotation;
        }
        pole.transform.eulerAngles = new Vector3(
            0,
            0,
            curRotation
        );
        foreach (Transform child in pole.transform) {
            child.transform.localEulerAngles = new Vector3(
                0,
                0,
                rotationOffset
            );
        }
    }

    public void CreateEquation(){
        left.returnTerms(out double _leftXTerm, out double leftTerm);
        right.returnTerms(out double _rightXTerm, out double rightTerm);
        Equation equation = new Equation(_leftXTerm, leftTerm, _rightXTerm, rightTerm);
        SceneManagement.ChangeToEquation(equation);
    }
}
