using UnityEngine;
using ScrollWheels;
using System;

public class MathInput : MonoBehaviour
{
    bool rightHandlePulled;
    public static EquationLevel Equation;
    [SerializeField] GameObject bulgeR;
    [SerializeField] GameObject bulgeL;
    [SerializeField] SolvedScreen equationSolvedScreen;
    [SerializeField] EquationDisplay display;
    [SerializeField] FindElement[] input;
    [SerializeField] Animator errorAnimator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClip;
    string[] output;

    void OnEnable() {
        HandleEvents.LeftHandlePulled += LeftHandlePulled;
        HandleEvents.RightHandlePulled += RightHandlePulled;
    }

    void RightHandlePulled() {
        if (rightHandlePulled) return;
        rightHandlePulled = true;
        bulgeL.SetActive(true);
        bulgeR.SetActive(true);
        output = new string[3];
        for (int i = 0; i < input.Length; i++) {
            output[i] = input[i].elementInfo;
        }
        Invoke(nameof(Send), 1.5f);
    }

    void LeftHandlePulled() {
        Undo();
    }

    void OnDisable() {
        HandleEvents.LeftHandlePulled -= LeftHandlePulled;
        HandleEvents.RightHandlePulled -= RightHandlePulled;
    }

    void Awake() {
        SetActiveEquation();
        output = new string[3];
    }

    void FixedUpdate() {
    }

    public void Send(){
        if (ViableOutput()) {
            audioSource.PlayOneShot(audioClip[1]);
            display.Apply(output);
        }
        rightHandlePulled = false;
        if (Equation.Solution(out _)) {
            Invoke(nameof(EquationSolved), 1f);
        }
    }

    void EquationSolved() {
        Equation.Solution(out double valueOfX);
        equationSolvedScreen.ActiveScreen(Equation.CalculateScore(),valueOfX);
        audioSource.PlayOneShot(audioClip[2]);
        audioSource.PlayOneShot(audioClip[3]);
    }
    public bool ViableOutput(){
        if (output[2].Contains("x")  && !(output[0].Contains('+') || output[0].Contains('-'))) {
            errorAnimator.Play("ErrorOnSign");
            audioSource.PlayOneShot(audioClip[0]);
            return false;
        } if (String.Join("", output).Length == 1) {
            errorAnimator.SetTrigger("ErrorOnValues");
            audioSource.PlayOneShot(audioClip[0]);
            return false;
        }
        if (output[1].Length == 0)
            output[1] = "1";
        return true;
    }

    public void SetActiveEquation(){
        display.SetActiveEquation(Equation);
    }

    public void Undo(){
        display.Previous();
    }

    public void Reset() {
        Equation.Reset();
    }
}