using UnityEngine;
using ScrollWheels;
using System;

public class MathInput : MonoBehaviour
{
    [HideInInspector] public bool rightHandlePulled;
    public static EquationLevel Equation;
    [SerializeField] ParticleSystem smokeOnApplyR;
    [SerializeField] ParticleSystem smokeOnApplyL;
    [SerializeField] GameObject bulgeR;
    [SerializeField] GameObject bulgeL;
    [SerializeField] SolvedScreen equationSolvedScreen;
    [SerializeField] EquationDisplay display;
    [SerializeField] FindElement[] input;
    [SerializeField] Animator errorAnimator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClip;
    public string[] output;
    public string[] outputPreview;

    void OnEnable() {
        HandleEvents.LeftHandlePulled += LeftHandlePulled;
        HandleEvents.RightHandlePulled += RightHandlePulled;
    }

    void OnDisable() {
        HandleEvents.LeftHandlePulled -= LeftHandlePulled;
        HandleEvents.RightHandlePulled -= RightHandlePulled;
    }

    void Awake() {
        SetActiveEquation();
        output = new string[3];
        outputPreview = output;
    }

    void Update() {
         for (int i = 0; i < input.Length; i++) {
             outputPreview[i] = input[i].elementInfo;
         }
    }

    void RightHandlePulled() {
        if (rightHandlePulled) return;
        rightHandlePulled = true;
        output = new string[3];
        for (int i = 0; i < input.Length; i++) {
            output[i] = input[i].elementInfo;
        }
        if (!ViableOutput()) {
            Send(); 
            return;
        }
        bulgeL.SetActive(true);
        bulgeR.SetActive(true);
        var smokeDelay = 1.5f;
        Invoke(nameof(SmokeOnPull), smokeDelay);
        var delay = 2.1f; //Let the smoke cover the numbers before they change.
        Invoke(nameof(Send), delay);
    }

    void SmokeOnPull()
    {
        smokeOnApplyR.Play();
        smokeOnApplyL.Play();
        audioSource.volume = .5f; //justere lydniveau;
        audioSource.PlayOneShot(audioClip[3]); //lydklip til røg der kommer ud
    }
    void LeftHandlePulled() {
        Undo();
    }
    public void Send() {
        if (ViableOutput()) {
            display.Apply(output);
        } else {
            errorAnimator.Play("ErrorOnSign");
            audioSource.PlayOneShot(audioClip[0]);
            errorAnimator.Play("ErrorOnx");
        }
        rightHandlePulled = false;
        if (Equation.Solution(out _)) {
            var delay = 1.5f;
            Invoke(nameof(EquationSolved), delay);
        }
    }

    bool ViableOutput() {
        if (output[2].Contains("x") && !(output[0].Contains('+') || output[0].Contains('-'))) {
            return false;
        }
        if (String.Join("", output).Length == 1) {
            return false;
        }
        if (output[1].Length == 0) {
            output[1] = "1";
        }
        return true;
    }
    
    void EquationSolved() {
        LevelManager.ActiveLevel.Complete();
        Equation.Solution(out double valueOfX);
        equationSolvedScreen.ActiveScreen(valueOfX);
        audioSource.volume = .25f;     //Changing the volume since the sound effect is pretty loud and I'm pretty lazy.
        audioSource.PlayOneShot(audioClip[1]);
        audioSource.PlayOneShot(audioClip[2]);
    }

    public bool ViableOutputPreview() //Bliver brugt til at preview hvad man har på scroll wheel (i OutputVisualizer.cs)
    {
        if (outputPreview[2].Contains("x") && !(outputPreview[0].Contains('+') || outputPreview[0].Contains('-'))) {
            return false;
        }

        if (String.Join("", outputPreview).Length == 1){
            return false;
        }

        if (outputPreview[1].Length == 0){
            outputPreview[1] = "1";
        }
        return true;
    }

    public void SetActiveEquation(){
        display.SetActiveEquation(Equation);
    }

    public void Undo(){
        display.Previous();
    }
}