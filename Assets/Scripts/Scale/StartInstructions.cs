using UnityEngine;
using TMPro;

public class StartInstructions : MonoBehaviour
{
    [SerializeField] GameObject entranceAnimation;
    [SerializeField] TextMeshProUGUI textDisplay;
    
    [TextArea][SerializeField] string[] instructionText = new string[3];
    [SerializeField] GameObject[] tutorialImages;

    GameObject currentGraphic, prevGraphic;
    int playerClicks;
    bool playerHasClicked;
    
    void Start() {
        Time.timeScale = 0;
        textDisplay.text = instructionText[playerClicks];
        currentGraphic = Instantiate(tutorialImages[playerClicks], transform);
        currentGraphic.transform.SetAsLastSibling();
        if (entranceAnimation)
            entranceAnimation.SetActive(false);
    }

    public void ChangeText() {
        playerClicks++;
        playerHasClicked = true;
        if(playerClicks == instructionText.Length) {
            Time.timeScale = 1;
            if (entranceAnimation)
                entranceAnimation.SetActive(true);
            Destroy(gameObject);
        }
        else 
        {
            currentGraphic.SetActive(false);
            currentGraphic = Instantiate(tutorialImages[playerClicks], transform);
            currentGraphic.transform.SetAsLastSibling();
            textDisplay.text = instructionText[playerClicks];
        }
    }

    public void Skip() {
        Time.timeScale = 1;
        if (entranceAnimation)
            entranceAnimation.SetActive(true);
        Destroy(gameObject);
    }
}
