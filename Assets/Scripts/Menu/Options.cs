using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Options : MonoBehaviour {
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject resetButton;
    [SerializeField] MathInput mathInput;
    [SerializeField] Image soundButton;
    [SerializeField] Color enableColor;
    [SerializeField] Color disableColor;
    public static bool soundState {get; private set;} = true;
    string mainMenuName = "MainMenu";

    void Start(){
        if (mathInput == null)
            resetButton.SetActive(false);
        AudioListener.volume = Convert.ToSingle(soundState);
        enableColor = new Color32(100,255,100,200);
        disableColor = new Color32(255,100,100,200);
    }

    void Update(){
        if (soundState){
            soundButton.color = enableColor;
        } else {
            soundButton.color = disableColor;
        }
    }

    public void ToggleMenu() {
        optionsMenu.SetActive(!optionsMenu.activeSelf);
        resetButton.SetActive(mathInput != null && mathInput.gameObject.activeSelf);
    }

    public static void ToggleSound() {
        soundState = !soundState;
        AudioListener.volume = Convert.ToSingle(soundState);
    }

    public void CallReset(){
        if (mathInput != null) {
            mathInput.Reset();
            ToggleMenu();
        }
    }

    public void ReturnToMainMenu(){
        SceneManagement.StaticChangeScene(mainMenuName);
    }
}
