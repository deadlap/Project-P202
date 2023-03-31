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
    [SerializeField] float rotationModifier;
    void Start(){
        finishButton.SetActive(false);
    }

    void Update(){
        float curRotation = 0;
        float rotationOffset = 0;
        if(left.CalculateSum(out double leftSum) && right.CalculateSum(out double rightSum)) {
            finishButton.SetActive(leftSum == rightSum);

            switch (leftSum, rightSum) {
                case (0, 0):
                    curRotation = 0;
                    break;
                case (0, _):
                    curRotation = (leftSum > rightSum ? (float)(1/rightSum)*rotationModifier : curRotation);
                    curRotation = (leftSum < rightSum ? -(float)(rightSum/1)*rotationModifier : curRotation);
                    break;
                case (_, 0):
                    curRotation = (leftSum > rightSum ? (float)(leftSum/1)*rotationModifier : curRotation);
                    curRotation = (leftSum < rightSum ? -(float)(1/leftSum)*rotationModifier : curRotation);
                    break;
                default:
                    curRotation = (leftSum > rightSum ? (float)(leftSum/rightSum)*rotationModifier : curRotation);
                    curRotation = (leftSum < rightSum ? -(float)(rightSum/leftSum)*rotationModifier : curRotation);
                    break;
            }
            if (leftSum < 0 || rightSum < 0)
                curRotation = -curRotation;
                
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
