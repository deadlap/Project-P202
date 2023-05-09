using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class OutputVisualizer : MonoBehaviour {
    [SerializeField] List<TextMeshProUGUI> textDisplays;
    [SerializeField] List<GameObject> errorImages;
    [SerializeField] MathInput mathInput;
    void Update() {
        if (Time.timeScale == 0) return;
        for (int i = 0; i < textDisplays.Count; i++) {
            if (mathInput.ViableOutputPreview()){
                textDisplays[i].text = String.Join("",mathInput.outputPreview);
                errorImages[i].SetActive(false);
            } else {
                textDisplays[i].text = "";
                errorImages[i].SetActive(true);
            }     
        }
    }
}
