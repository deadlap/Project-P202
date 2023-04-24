using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] public Level level;
    [SerializeField] public List<GameObject> stars;
    public GameObject playLevelButton;

    void Start() {
        if (level.equation == null)
            return;
        for (int i = 0; i < stars.Count; i++) {
            if (i+1>level.CalculateScore())
                return;
            stars[i].SetActive(true);
        }
    }

    public void SendToLevel(){
        if (level.unlocked) {
            if (level.CalculateScore() > 0) {
                level.Reset();
            }
            SceneManagement.GoToLevel(level);
        } else {
            //Indsæt ryste-animation-ting
        }
    }
}
