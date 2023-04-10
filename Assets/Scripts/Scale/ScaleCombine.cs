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
    [SerializeField] float rotationPerSecond;
    [SerializeField] float targetRotation = 0;
    [SerializeField] float rotationThreshold;
    void Start(){
        finishButton.SetActive(false);
    }

    void Update(){
        float rotationOffset = 0;
        if(left.CalculateSum(out double leftSum) && right.CalculateSum(out double rightSum)) {
            finishButton.SetActive(leftSum == rightSum);

            switch (leftSum, rightSum) {
                case (0, 0):
                    targetRotation = 0;
                    break;
                case (_,_) when leftSum == rightSum:
                    targetRotation = 0;
                    break;
                case (0, _):
                    targetRotation = (leftSum > rightSum ? (float)(1/rightSum)*rotationModifier : targetRotation);
                    targetRotation = (leftSum < rightSum ? -(float)(rightSum/1)*rotationModifier : targetRotation);
                    break;
                case (_, 0):
                    targetRotation = (leftSum > rightSum ? (float)(leftSum/1)*rotationModifier : targetRotation);
                    targetRotation = (leftSum < rightSum ? -(float)(1/leftSum)*rotationModifier : targetRotation);
                    break;
                default:
                    targetRotation = (leftSum > rightSum ? (float)(leftSum/rightSum)*rotationModifier : targetRotation);
                    targetRotation = (leftSum < rightSum ? -(float)(rightSum/leftSum)*rotationModifier : targetRotation);
                    break;
            }
            if (leftSum < 0 || rightSum < 0) {
                targetRotation = -targetRotation;
            }
            targetRotation = (targetRotation > rotationMax ? rotationMax : targetRotation);
            targetRotation = (targetRotation < -rotationMax ? -rotationMax : targetRotation);
        }
        float currentRotation = pole.transform.localEulerAngles.z > 180 ? -360+pole.transform.localEulerAngles.z : pole.transform.localEulerAngles.z;
        if (rotationThreshold >= Math.Abs(targetRotation-currentRotation)) {
            currentRotation = targetRotation;
        } else {
            if (currentRotation < targetRotation) {
                currentRotation += rotationPerSecond*Time.deltaTime;
            } else {
                currentRotation -= rotationPerSecond*Time.deltaTime;
            }
        }
        rotationOffset = -currentRotation;
        pole.transform.eulerAngles = new Vector3(
            0,
            0,
            currentRotation
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
