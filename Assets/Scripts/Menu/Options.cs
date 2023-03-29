using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject resetButton;
    [SerializeField] MathInput mathInput;
    [SerializeField] AudioClip backgroundMusic;
    public static AudioSource effectSource {get; private set;}
    public static AudioSource musicSource {get; private set;}
    public static bool soundState {get; private set;}
    string equationSceneName = "EquationRandom";
    string mainMenuName = "MainMenu";

    void Start(){
        if (SceneManager.GetActiveScene().name != equationSceneName)
            resetButton.SetActive(false);
        if (effectSource != null && musicSource != null ){
            effectSource = new AudioSource();
            musicSource = new AudioSource();
            musicSource.loop = true;
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    public void ToggleMenu() {
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }

    public static void ToggleSound() {
        soundState = !soundState;
        effectSource.mute = soundState;
        musicSource.mute = soundState;
    }
    
    public static void PlayEffect(AudioClip clip){
        effectSource.clip = clip;
        effectSource.Play();
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
