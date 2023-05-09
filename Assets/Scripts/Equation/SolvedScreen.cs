using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SolvedScreen : MonoBehaviour {
    [SerializeField] GameObject equationSolvedScreen;
    [SerializeField] public List<GameObject> stars;
    [SerializeField] TextMeshProUGUI xValueText;
    [SerializeField] TextMeshProUGUI stepsText;
    [SerializeField] GameObject levelSelectButton; 

    public void ActiveScreen(double valueOfX){
        equationSolvedScreen.SetActive(true);
        if(GameMode.coopModeActive == true)
        {
            levelSelectButton.SetActive(false);
        }
        stepsText.text = LevelManager.ActiveLevel.equation.steps.ToString();
        xValueText.text = "x = " + valueOfX;
        for (int i = 0; i < stars.Count; i++) {
            if (i+1>LevelManager.ActiveLevel.score)
                return;
            stars[i].SetActive(true);
        }
    }

    public void CloseLevel(string scene) {
        //LevelManager.ActiveLevel.Complete();
        SceneManagement.StaticChangeScene(scene);
    }
}