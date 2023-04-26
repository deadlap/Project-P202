using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlockManager : MonoBehaviour {
    void Awake() {
        LevelButton[] Components = GetComponentsInChildren<LevelButton>();
        for (int i = 0; i < Components.Length-1; i++) {
            if (Components[i].level.completed) {
                Components[i+1].level.unlocked = true;
            }
        }
    }
}