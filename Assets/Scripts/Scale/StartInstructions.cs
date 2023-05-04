using UnityEngine;
using TMPro;

public class StartInstructions : MonoBehaviour
{
    [SerializeField] GameObject entranceAnimation;
    [SerializeField] TextMeshProUGUI textDisplay;

    [SerializeField] string[] instructionText = new string[3];
    int i;


    // Start is called before the first frame update
    void Start()
    {
        textDisplay.text = instructionText[i];
        entranceAnimation.SetActive(false);
    }

    public void ChangeText()
    {
        i++;
        if(i == instructionText.Length)
        {
            Destroy(gameObject);
            entranceAnimation.SetActive(true);
        }
        else
        {
            textDisplay.text = instructionText[i];
        }
    }




}
