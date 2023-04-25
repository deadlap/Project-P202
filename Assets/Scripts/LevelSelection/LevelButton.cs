using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] public Level level;
    [SerializeField] public List<GameObject> stars;
    void Awake() {
        for (int i = 0; i < stars.Count; i++) {
            if (i+1>level.score)
                return;
            stars[i].SetActive(true);
        }
    }

    public void SendToLevel(){
        if (level.unlocked) {
            level.Reset();
            SceneManagement.GoToLevel(level);
        } else {
            //Indsæt ryste-animation-ting
        }
    }
}
