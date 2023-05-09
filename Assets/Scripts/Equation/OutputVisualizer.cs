using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class OutputVisualizer : MonoBehaviour {
    [SerializeField] List<TextMeshProUGUI> textDisplays;
    [SerializeField] List<GameObject> errorImages;
    [SerializeField] MathInput mathInput;
    void Update()
    {
        if (!mathInput.rightHandlePulled) return; //undgår null references der opstår når man ikke har trukket i håndtaget.  
        for (int i = 0; i < textDisplays.Count; i++) {
            if (mathInput.ViableOutput()){
                textDisplays[i].text = String.Join("",mathInput.output);
                errorImages[i].SetActive(false);
            } else {
                textDisplays[i].text = "";
                errorImages[i].SetActive(true);
            }     
        }
    }
}
