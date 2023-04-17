using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SolvedScreen : MonoBehaviour {
    [SerializeField] GameObject equationSolvedScreen;
    [SerializeField] public List<GameObject> stars;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI xValueText;

    public void ActiveScreen(int score, double valueOfX){
        equationSolvedScreen.SetActive(true);
        scoreText.text = score.ToString();
        xValueText.text = valueOfX.ToString();
        for (int i = 0; i < stars.Count; i++) {
            if (i+1>score)
                return;
            stars[i].SetActive(true);
        }
    }
}