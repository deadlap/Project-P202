using UnityEngine;
using TMPro;

public class StartInstructions : MonoBehaviour
{
    [SerializeField] GameObject tubeEntrance;
    [SerializeField] TextMeshProUGUI textDisplay;

    [SerializeField] string[] instructionText = new string[3];
    int i;


    // Start is called before the first frame update
    void Start()
    {
        tubeEntrance.SetActive(false);
        textDisplay.text = instructionText[i];
    }

    public void ChangeText()
    {
        i++;
        if(i == instructionText.Length)
        {
            Destroy(gameObject);
            tubeEntrance.SetActive(true);
        }
        else
        {
            textDisplay.text = instructionText[i];
        }
    }




}
