using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnableLevelSelection : MonoBehaviour {
    void Start() {
        this.gameObject.SetActive("LevelSelect"==SceneManager.GetActiveScene().name);
    }
}
