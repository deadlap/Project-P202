using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] public Level level;
    [SerializeField] List<GameObject> stars;
    [SerializeField] GameObject lockOnLevel;
    Animator levelAnimator;
    AudioSource levelAudioSource;

    void Awake()
    {
        levelAnimator = GetComponent<Animator>();
        levelAudioSource = GetComponent<AudioSource>();
    }

    // void Start() {
    //     lockOnLevel.SetActive(!level.unlocked);
    //     for (int i = 0; i < stars.Count; i++) {
    //         if (i+1>level.score)
    //             return;
    //         stars[i].SetActive(true);
    //     }
    // }

    public void SendToLevel(){
        // if (level.unlocked) {
        level.ResetLevel();
        SceneManagement.GoToLevel(level);
        // } else {
        //     levelAnimator.Play("LevelLocked");
        //     levelAudioSource.Play(); //OneShot(levelAudioSource.clip));
        //     //Indsæt ryste-animation-ting
        // }

    }
}
