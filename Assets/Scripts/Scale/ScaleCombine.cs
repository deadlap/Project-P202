using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScaleCombine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI equalityText;
    [SerializeField] ScaleMath leftValueOfTerm;
    [SerializeField] ScaleMath rightValueOfTerm;
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
        if(leftValueOfTerm.CalculateSum(out double leftSum) && rightValueOfTerm.CalculateSum(out double rightSum)) {
            finishButton.SetActive(leftSum == rightSum);
            if (leftSum<rightSum) {
                equalityText.text = "<";
                targetRotation = -rotationMax;
            } else if (leftSum>rightSum) {
                equalityText.text = ">";
                targetRotation = rotationMax;
            } else {
                targetRotation = 0;
                equalityText.text = "=";
            }
        } else {
            finishButton.SetActive(false);
            equalityText.text = "≠";
            targetRotation = 0;
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
        var rotationOffset = -currentRotation;
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
        leftValueOfTerm.returnTerms(out double _leftXTerm, out double leftTerm);
        rightValueOfTerm.returnTerms(out double _rightXTerm, out double rightTerm);
        Equation equation = new Equation(_leftXTerm, leftTerm, _rightXTerm, rightTerm);
        LevelManager.ActiveLevel.SetEquation(equation);
        SceneManagement.GoToLevel(LevelManager.ActiveLevel);
    }
}
