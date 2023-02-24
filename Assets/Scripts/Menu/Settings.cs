using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Settings", menuName = "Project-P202/Settings", order = 0)]
[Serializable]
public class Settings : ScriptableObject {
    public static bool soundEnabled {get; private set;}
    public static void ChangeSetting() {
        soundEnabled = !soundEnabled;
    }
}