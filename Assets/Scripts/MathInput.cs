using UnityEngine;
using ScrollWheels;
using System;

public class MathInput : MonoBehaviour {
    public static EquationLevel Equation;
    [HideInInspector] public HandleInteraction handleInteraction;
    [SerializeField] EquationDisplay display;
    [SerializeField] FindElement[] input;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource mathAudioSource;
    [SerializeField] AudioClip[] audioClip;
    string[] output;

    void OnEnable() {
        HandleEvents.LeftHandlePulled += LeftHandlePulled;
        HandleEvents.RightHandlePulled += RightHandlePulled;
    }

    void RightHandlePulled() {
        Send();
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
        output = new string[3];
        for (int i = 0; i < input.Length; i++) {
            output[i] = input[i].elementInfo;
        }
    }

    public void Send() {
        if (ViableOutput()) {
            mathAudioSource.PlayOneShot(audioClip[1]);
            Equation = display.Apply(output);
        }
    }

    public bool ViableOutput(){
        if (output[2].Contains("x")  && !(output[0].Contains('+') || output[0].Contains('-'))) {
            animator.Play("ErrorOnSign");
            mathAudioSource.PlayOneShot(audioClip[0]);
            return false;
        } if (String.Join("", output).Length == 1) {
            animator.SetTrigger("ErrorOnValues");
            mathAudioSource.PlayOneShot(audioClip[0]);
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