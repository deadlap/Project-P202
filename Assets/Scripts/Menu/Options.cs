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
    [SerializeField] bool isLevelScene;
    string mainMenuName = "MainMenu";

    void Start(){
        resetButton.SetActive(isLevelScene);
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
        // resetButton.SetActive(isLevelScene);
    }

    public static void ToggleSound() {
        soundState = !soundState;
        AudioListener.volume = Convert.ToSingle(soundState);
    }

    public void CallReset(){
        if (isLevelScene) {
            LevelManager.ResetActiveLevel();
            ToggleMenu();
        }
    }

    public void ReturnToMainMenu(){
        SceneManagement.StaticChangeScene(mainMenuName);
    }
}
