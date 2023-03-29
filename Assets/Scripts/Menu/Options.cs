using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject resetButton;
    [SerializeField] MathInput mathInput;
    [SerializeField] AudioSource audioSource;
    public static bool soundState {get; private set;}
    string equationSceneName = "EquationRandom";
    string mainMenuName = "MainMenu";

    void Start(){
        if (SceneManager.GetActiveScene().name != equationSceneName)
            resetButton.SetActive(false);
    }

    public void ToggleMenu() {
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }

    public void ToggleSound() {
        soundState = !soundState;
        audioSource.mute = soundState;
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
