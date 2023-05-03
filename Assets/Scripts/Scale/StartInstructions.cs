using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartInstructions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textDisplay;

    [SerializeField] string[] instructionText = new string[3];
    int i = 0;


    // Start is called before the first frame update
    void Start()
    {
        textDisplay.text = instructionText[i];
    }

    public void ChangeText()
    {
        i++;
        if(i == instructionText.Length)
        {
            Destroy(this.gameObject);
        }
        else
        {
            textDisplay.text = instructionText[i];
        }
    }




}
